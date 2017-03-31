# .NET 三方支付

## 简介
> __用.NET提供的三方支付，`Payment`提供了基础支付能力，因项目的需要在`Payment`的基础上，扩展对富友（`Payment.Fuiou`）和银生宝(`Payment.Unspay`)的支持，当然用户也可在Payment的基础上扩展其它支付渠道;__

## 说说支付
> __不知道做过支付的同学是不是和我的感觉一样，我认为涉及到支付的方面如下：__

![payment ac icon](https://github.com/x-share/payment/blob/master/Design/p1.png)

> **总之合理的划分，有助于我们下一步工作，如何降低模块之间的耦合，如何增加扩展性，是我们的原则；模块划分开了，做事的原则高清啦，我想我们已经想到该怎么做了。**

## 项目
> __这是做事的方式，我们尽量让它落地，毕竟带来的效果出其的不意；下面我们说说这个项目。__

### 模块关系不用说
![payment rela icon](https://github.com/x-share/payment/blob/master/Design/p2.png)

### 先谈Payment
> __所谓敏捷，先满足现状和之前，及时整理，不留下技术债务__

* 支付基础参数：BaseParemetor(AbsAccount)
* 通讯方式：IHttpProcesser
* 日志：ILog
* 序列化：ISerializable

> __读源代码的同学会发现，log给注掉了，这是因为本程序是切割版，对平台日志有很强依赖关系，这块很简单，我们可以自己加；当然如果我们的通讯方式不是http，这时候我们可以再提一层ICommunicate；`原则是一样的，但是富有很强的灵活性，使我们所需掌握的`！__

### 在谈扩展如何
> __以多变的参数为例：__

#### 支付基础参数：BaseParemetor
``` csharp
    /// <summary>
    /// 支付基础参数
    /// </summary>
    public abstract class BaseParemetor : AbsAccount
    {
        #region Abstract Method
        /// <summary>
        /// 获取格式数据
        /// </summary>
        /// <returns></returns>
        public abstract IDictionary<string, string> GetFormatData();
        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public abstract string GetRequestUrl();
        #endregion
    }
```
#### 富友如何实现
``` csharp
    public class FuiouParemetor : BaseParemetor
    {
        ... ...
        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <returns></returns>
        public virtual string GetSignature()
        {
            ... ...
        }

        /// <summary>
        /// 获取富有格式数据
        /// </summary>
        /// <returns></returns>
        public override IDictionary<string, string> GetFormatData()
        {
            ... ...
        }
        public override string GetRequestUrl()
        {
           ... ...
        }
        ... ...
    }

     /// <summary>
    /// 参数:42 商户P2P网站免登录用户更换银行卡接口
    /// </summary>
    public class ChangeCardParemetor : FuiouParemetor
    {
        
        /// <summary>
        /// 个人用户
        /// </summary>
        [Paremetor("login_id")]
        public string User { get; set; }
        
        /// <summary>
        /// 商户返回地址
        /// </summary>
        [Paremetor("page_notify_url")]
        public string NotifyUrl { get; set; }
        
        /// <summary>
        /// 字段
        /// </summary>
        /// <returns></returns>
        protected override string[] GetDataFields()
        {
            return new string[] { "login_id", "mchnt_cd", "mchnt_txn_ssn", "page_notify_url","signature" };
        }

        /// <summary>
        /// 获取访问的路径
        /// </summary>
        /// <returns></returns>
        public override string GetRequestUrl()
        {
            return FuiouConfig.ApiAddress["Fuyou.ChangeCard.Action"];
        }
        /// <summary>
        /// 设置验证字段
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<VALIDATE> SetValiDateFields()
        {
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.User, 11, "用户登录ID");
            yield return VALIDATE.NOTNULLANDLIMITLENGTH(this.NotifyUrl, 200, "商户前端接收交易结果地址");
        }
    }
```

### 可以在看看银生宝
```` csharp
    /// <summary>
    /// 银生宝基础接口
    /// </summary>
    public class UnspayParemetor : BaseParemetor
    {
        ... ...
        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <returns></returns>
        public virtual string GetSignature()
        {
            ... ...
        }
        public override IDictionary<string, string> GetFormatData()
        {
            ... ...
        }
        ... ...
    }

````
####  看看调用情况如何
```` csharp
var response= new Provider().Process(new Payment.Fuiou.Paremetors.ChangeCardParemetor());
````
> 是不是简单方便？但是...?如何这个账户改成银生宝了怎么办？或者改成其它支付方式了怎么办？

> 如果你发现这个问题，我们可以交流一下，毕竟这个问题不难，因为参数毕竟是       `AbsAccount`类型，你说呢？

## Author
* QQ：1919305111

