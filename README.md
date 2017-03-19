# .NET 三方支付

## 简介
> __用.NET提供的三方支付，`Payment`提供了基础支付能力，因项目的需要在`Payment`的基础富友（`Payment.Fuiou`）和银生宝(`Payment.Unspay`)的支持，当然用户也可在Payment的基础上扩展其它支付渠道;__

## 说说支付
> __不知道做过支付的同学是不是和我的感觉一样，我认为涉及到支付的方面如下：__

![payment ac icon](https://github.com/x-share/payment/blob/master/Design/p1.png)

> **总之合理的划分，有助于我们下一步工作，如何降低模块之间的耦合，如何增加扩展性，是我们的原则；模块划分开了，做事的原则高清啦，我想我们已经想到该怎么做了。**