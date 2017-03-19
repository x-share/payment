# .NET 三方支付

## 简介
> __用.NET提供的三方支付，`Payment`提供了基础支付能力，因项目的需要在`Payment`的基础富友（`Payment.Fuiou`）和银生宝(`Payment.Unspay`)的支持，当然用户也可在Payment的基础上扩展其它支付渠道;__

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

> __读源代码的同学会发现，log给注掉了，这是因为本程序是切割版，对平台日志有很强依赖关系，这块很简单，我们可以自己加；当然如果我们的通讯方式不是http，这时候我们可以再提一层ICommunicate；`原则是一样的，但是富有很强的灵狐独，使我们所需掌握的`！__

## Author
* QQ：1919305111

