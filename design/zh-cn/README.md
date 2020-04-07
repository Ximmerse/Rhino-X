# 介绍

MR (混合现实) 技术将改变我们使用计算机的方式。它很强大，但由于该领域很新，为其打造优秀的用户体验也不简单。

[Ximmerse](https://www.ximmerse.com) 专注于MR的技术开发，同时也关注MR领域的人机交互设计研究。我们自己为Rhino-X开发内容，也在不断尝试新的方式来使用MR技术。

经过多年的研究和很多次的犯错，我们将我们学到的经验浓缩到你正在阅读的这份《MR设计指南》里。我们也在创建诸如*混合现实游乐场*和*MRITK(混合现实交互工具箱)*这样的工具，这样你就能亲身体验这些指南，并使用我们的代码用于你自己的项目。敬请期待！

## Rhino X有什么特别的？
大多数MR头显的视场角都很有限，而Rhino X有着50°的水平视场角和57°的视场角，这能给你带来独一无二的沉浸式MR体验。Ximmerse还发明了独特的X-tag跟踪技术，它能为任意物体带来高速稳定的跟踪，提供更丰富的交互可能。

## 为什么要写这份设计指南？
大部分MR头显的开发者网站上都有它们自己的设计指南。在这份文档中，我们无意总结他人的贡献，而是想向社区贡献我们自己的研究成果。
诸如[存在感](/illusion?id=存在感)、[颜色规范](/interface?id=我们的工作)、[眼部空间UI](/interface?id=眼部空间ui标准)以及[远场交互技巧](/interaction?id=单手手柄的最佳实践指南)等概念都是我们对社区的独特贡献。我们期待听到你的意见和建议。

## 什么是MR？它和VR、AR不同在哪？
科技圈最不缺的就是新概念，如VR（虚拟现实）、AR（增强现实）、Spatial Computing（空间计算）等。下面这个视频（暂时需要科学上网）很好地解释了这些概念的区别：

<iframe width="100%" height="300" src="https://www.youtube.com/embed/TjsIyDn5H44" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

我们对MR（混合现实）的定义是一个至少包含六自由度头部跟踪的双目光学穿透头显（optical-see-through stereo head mounted display）。Magic Leap One, HoloLens and Rhino X 都属于这个范畴。而谷歌眼镜、ARKit等则不属于。

<!-- Begin Mailchimp Signup Form -->
<link href="//cdn-images.mailchimp.com/embedcode/horizontal-slim-10_7.css" rel="stylesheet" type="text/css">
<style type="text/css">
  #mc_embed_signup{background:#fff; clear:left; font:14px Helvetica,Arial,sans-serif; width:100%; margin-top: 80px;}
  #mc_embed_signup form {
    text-align: left;
  }
  #mc_embed_signup .button  {
    background: #3f51b5;
    color: white;
  }
</style>
<div id="mc_embed_signup">
<form action="https://github.us4.list-manage.com/subscribe/post?u=98e146615feaa80a87c9e26a2&amp;id=29c6a9379d" method="post" id="mc-embedded-subscribe-form" name="mc-embedded-subscribe-form" class="validate" target="_blank" novalidate>
    <div id="mc_embed_signup_scroll">
  <label for="mce-EMAIL">我们在努力优化这份文档，👋欢迎订阅！ </label>
  <input type="email" value="" name="EMAIL" class="email" id="mce-EMAIL" placeholder="email address" required>
    <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
    <div style="position: absolute; left: -5000px;" aria-hidden="true"><input type="text" name="b_98e146615feaa80a87c9e26a2_29c6a9379d" tabindex="-1" value=""></div>
    <div class="clear"><input type="submit" value="OK⏎" name="subscribe" id="mc-embedded-subscribe" class="button"></div>
    </div>
</form>
</div>

<!-- ### VR vs AR vs MR
The usage for VR (Virtual Reality) is quite narrow, it's a device that transports you into another virtual world, like Oculus Quest or HTC Vive. The term AR (Augmented Reality) is used more widely. It can be powered by a smart phone (Vuforia, Snapchat AR, or Lens Studio) or a head m

### Optical-see-through vs Video-see-through


### Stereo Head Mounted Display


### 6 Degree of Freedom -->