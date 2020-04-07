# 存在感

如果说VR追求“沉浸感”， 那么MR追求的则是“存在感”。 我们应该想尽办法欺骗用户的感官，使其相信面前看到的虚拟物体就是真实**“存在”**于他们身边的空间中。如何做到这一点呢？

## 为虚拟物体提供“着地感”
目前主流的MR头显如HoloLens，Rhino-X和Magic Leap都属于光学穿透（optical see through）MR头显，因此只能往用户视野中加光而不能减光，也就无法直接渲染深色阴影。而阴影是一个重要的“着地感”的来源。我们可以使用其他技巧来补齐这一空缺。

<table class="DoDont_table" cellspacing="100">
  <tr>
    <th><video width="100%" autoplay loop muted  src="videos/Hologram_football.mp4"></video></th>
    <th class="divider"></th>
    <th><video width="100%" autoplay loop muted  src="videos/dinosaur_shadow.mp4"></th>
  </tr>
  <tr class="DoDont_tr">
    <td class="Do_td">Do</td>
    <td class="divider"></td>
    <td class="Do_td">Do</t>
  </tr>
  <tr class="content">
    <td>在强烈反光平面上加入平面反射。反射是一个很强的“着地感”来源。</td>
    <td class="divider"></td>
    <td>通过加入强光源照亮阴影周围的地面，使得阴影能被感知。</t>
  </tr>
</table>
<table class="DoDont_table" cellspacing="100">
  <tr>
    <th><img alt="" src="images/magic leap rockets.gif" width="100%"></th>
    <th class="divider"></th>
    <th><img alt="" src="images/drive_buggydemo.gif" width="100%"></th>
  </tr>
  <tr class="DoDont_tr">
    <td class="Do_td">Do</td>
    <td class="divider"></td>
    <td class="Do_td">Do</td>
  </tr>
  <tr class="content">
    <td>创造一些能与环境（地面、墙面等）交互的物体，如粒子。[图片: <a target="_blank" href="https://www.magicleap.com/news/partner-stories/weta-launches-rocket-game-on-magic-leap-world">Magic Leap</a>]</td>
    <td class="divider"></td>
    <td>在角色的脚上或轮子上加入着地特效。[图片: <a target="_blank" href="https://developer.magicleap.com/learn/guides/magickit-drive-design-diary">Magic Leap</a>]</t>
  </tr>
</table>
<table class="DoDont_table" cellspacing="100">
  <tr>
    <th><img alt="" src="images/google_translation.gif" width="100%"></th>
    <th class="divider"></th>
    <th></th>
  </tr>
  <tr class="DoDont_tr">
    <td class="Do_td">Do</td>
    <td class="divider"></td>
    <td class=""></td>
  </tr>
  <tr class="content">
    <td>加入紧贴在地面的UI元素，如代表地面的网格和代表落地点的圆框。[图片: <a target="_blank" href="https://designguidelines.withgoogle.com/ar-design/content/content-manipulation.html#content-manipulation-translation">谷歌</a>]</td>
    <td class="divider"></td>
    <td></td>
  </tr>
</table>

## 避免过高的“视野填充率”
混合现实有别于虚拟现实最大的特征在于用户仍然能看到真实环境。因此，内容需要为这一特征而专门设计，而不是生搬硬套虚拟现实的设计。
<table class="DoDont_table" cellspacing="100">
  <tr class="DoDont_tr">
    <td class="Dont_td">Don't</td>
    <td class="divider"></td>
    <td class="Dont_td">Don't</td>
  </tr>
  <tr class="content">
    <td>不要创建一个环绕着用户的巨大环境。这些环境元素会显得悬在空中，并且更容易导致晕动症。</td>
    <td class="divider"></td>
    <td>虚拟物体不应超出房间范围，要避免特别高大的物体或特别远的位置。它们会超出头显的视野范围或显得“不着地”。</td>
  </tr>
</table>
<table class="DoDont_table" cellspacing="100">
  <tr>
    <th><img alt="" src="images/AlexKipman_2016-embed.jpg" width="100%"></th>
    <th class="divider"></th>
    <th></th>
  </tr>
  <tr class="DoDont_tr">
    <td class="Do_td">Do</td>
    <td class="divider"></td>
    <td class=""></td>
  </tr>
  <tr class="content">
    <td>创造类似于“岛屿”一样的环境来营造氛围。[图片: <a href="https://www.ted.com/talks/alex_kipman_a_futuristic_vision_of_the_age_of_holograms" target="_blank">微软</a>]</td>
    <td class="divider"></td>
    <td></td>
  </tr>
</table>

## 对于深色要慎重
深色物体无法在光学穿透的MR头显中被直接看到。根据我们的测试，在正常室内环境中使用Rhino X，亮度低于0.5（基于HSV色彩规范）的颜色在独立显示的情况下对比度不足。

<table class="DoDont_table" cellspacing="100">
  <tr class="DoDont_tr">
    <td class="Do_td">Do</td>
    <td class="divider"></td>
    <td class="Do_td">Do</td>
  </tr>
  <tr class="content">
    <td>在制作美术资源时，尽量选择亮度高于50%的颜色。</td>
    <td class="divider"></td>
    <td>不要使用会造成强烈阴影的光照组合。可以使用unlit着色器和预先烘焙的全局光照。</t>
  </tr>
</table>
<table class="DoDont_table" cellspacing="100">
  <tr>
    <th><img alt="" src="images/hololens_dark_object.jpg" width="100%"></th>
    <th class="divider"></th>
    <th></th>
  </tr>
  <tr class="DoDont_tr">
    <td class="Do_td">Do</td>
    <td class="divider">
  </tr>
  <tr class="content">
    <td>是在要显示深色物体，使用边缘高亮（Rim light）的着色器即可。</td>
    <td class="divider"></td>
    <td></t>
  </tr>
</table>

## 追求无锯齿的视觉效果
现实世界是不存在锯齿的。在MR中，锯齿会极大地降低视觉效果。由于Rhino X头显的角分辨率相比PC和手机来说更低一些，锯齿会更容易被人眼察觉到。

<table class="DoDont_table" cellspacing="100">
  
  <tr class="DoDont_tr">
    <td class="Rec_td">Recommend</td>
    <td class="divider"></td>
    <td class="Dont_td">Don't</td>
  </tr>
  <tr class="content">
    <td>使用4x或更高的抗锯齿级别。</td>
    <td class="divider"></td>
    <td>不要使用过于精细的贴图，它们反而会加剧锯齿，显得画面在“闪烁”。
  </tr>
</table>
<table class="DoDont_table" cellspacing="100">
  
  <tr class="DoDont_tr">
    <td class="Dont_td">Don't</td>
    <td class="divider"></td>
    <td class=""></td>
  </tr>
  <tr class="content">
    <td>在4x或更低的抗锯齿级别下，不要用比 3dmm 更细的线条。根据我们的测试，它们的锯齿感会非常强。</td>
    <td class="divider"></td>
    <td></td>
  </tr>
</table>

<!-- ## Avoid precise alignment between virtual and real objects, like controllers

Exact alignment btween virtual and real wouldn't work very well since the tracking and optics are not accurate enough in this generation.

<table class="DoDont_table" cellspacing="100">
  <tr>
    <th><img alt="pic: a circle on a beacon" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAVwAAACRCAMAAAC4yfDAAAAAMFBMVEXZ2dnV1dW2traqqqrOzs7Jycm+vr7c3Nytra2zs7PGxsa7u7vKysrY2NjS0tLDw8N7mvbnAAAC50lEQVR4nO3c0XKbMBRFUQSYK4FB//+3lW1wgHJAlGSStns92Q7uNLuMcoVTigIAAAAAAAAAAAAAAAAAAAAAAAAAAAD4W1nhLkhvh2TRVxf45ru/gR/MmsqXF/iq49xV+so7u6AI1fDd38OPVVfNpTPP2ur2WX+Xf87VuAVxNeJ+IeJ+ofNx01w8zKZb4mrn4zZl05RdPz0lrnY6bqgfE9gQ3PicuNrJuNYNr8NdGF8hrnYy7jDtxyzeXw+Iq52M29bTo2F8H3G1k3Hje6/rOuIeOXvm3qdHnLnHTsZ15bTmNuMCQVzt7LTQ3J+H2zBVJq52es4tY5Hm3HuYdhHE1U7HtVtZdiG+nxNX+4MLN1b0s7cQV9uMG4f84MTVNuK60Pg6uy5xtd/iWp3K9iHm1iWuto5rzet6V5n7oS5xtVXcPnSvByly3h9AXG0RNy0Jt+mZtd5tv2WJuNo8rkU/LErnDA3E1eZxy3L5Nefvx3WJq73j2uB/mxByhgbialPctMRuzbZdtx7U1gsxcbUpbve+ErNgcTE0WFeu/w2Iqz3jmvPqCoPd50NDGdP+YnkocbVHXLtV+idXWounc7UPrX1sM0bE1R5xG+/2fm65cfidhofnBvn9VeJqddWF8uigtBo8zuD32DtfGoir1b5qD8cta7rHlmL+Ap9EZMi7WG5tWCy0s6WBuFp23PVLblwaiKtlxbVmY1kelwbiallxty/uphE4LQ3E1XLiBnGIuRD5Dyc7juM6r8eJtB2OxJWO4prb2b09lwZPXOUgrtXV/hXztHUmrrIfN6U7+jSCNVfbjWvx+HM04mp7cWebXI242l7c9Wdqm4ir6bh9yPq9EOJqMq7+cGKJuJqIa0OV+dtixNW246bx9pbXlrg7NuNaW2X/Dilxta24Fg+3Dh/HElfbusdNF3rucfMZNu7OFHzg7kyfI21xL+G+Ynu4Ix4AAAAAAAAAAAAAAAAAAAAAAAAAAAD+W78Aqjkan4b2aooAAAAASUVORK5CYII=" width="100%"></th>
    <th class="divider"></th>
    <th><img alt="pic: a dot and a line on a beacon" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAVwAAACRCAMAAAC4yfDAAAAAMFBMVEXZ2dnV1dW2traqqqrOzs7Jycm+vr7c3Nytra2zs7PGxsa7u7vKysrY2NjS0tLDw8N7mvbnAAAC50lEQVR4nO3c0XKbMBRFUQSYK4FB//+3lW1wgHJAlGSStns92Q7uNLuMcoVTigIAAAAAAAAAAAAAAAAAAAAAAAAAAAD4W1nhLkhvh2TRVxf45ru/gR/MmsqXF/iq49xV+so7u6AI1fDd38OPVVfNpTPP2ur2WX+Xf87VuAVxNeJ+IeJ+ofNx01w8zKZb4mrn4zZl05RdPz0lrnY6bqgfE9gQ3PicuNrJuNYNr8NdGF8hrnYy7jDtxyzeXw+Iq52M29bTo2F8H3G1k3Hje6/rOuIeOXvm3qdHnLnHTsZ15bTmNuMCQVzt7LTQ3J+H2zBVJq52es4tY5Hm3HuYdhHE1U7HtVtZdiG+nxNX+4MLN1b0s7cQV9uMG4f84MTVNuK60Pg6uy5xtd/iWp3K9iHm1iWuto5rzet6V5n7oS5xtVXcPnSvByly3h9AXG0RNy0Jt+mZtd5tv2WJuNo8rkU/LErnDA3E1eZxy3L5Nefvx3WJq73j2uB/mxByhgbialPctMRuzbZdtx7U1gsxcbUpbve+ErNgcTE0WFeu/w2Iqz3jmvPqCoPd50NDGdP+YnkocbVHXLtV+idXWounc7UPrX1sM0bE1R5xG+/2fm65cfidhofnBvn9VeJqddWF8uigtBo8zuD32DtfGoir1b5qD8cta7rHlmL+Ap9EZMi7WG5tWCy0s6WBuFp23PVLblwaiKtlxbVmY1kelwbiallxty/uphE4LQ3E1XLiBnGIuRD5Dyc7juM6r8eJtB2OxJWO4prb2b09lwZPXOUgrtXV/hXztHUmrrIfN6U7+jSCNVfbjWvx+HM04mp7cWebXI242l7c9Wdqm4ir6bh9yPq9EOJqMq7+cGKJuJqIa0OV+dtixNW246bx9pbXlrg7NuNaW2X/Dilxta24Fg+3Dh/HElfbusdNF3rucfMZNu7OFHzg7kyfI21xL+G+Ynu4Ix4AAAAAAAAAAAAAAAAAAAAAAAAAAAD+W78Aqjkan4b2aooAAAAASUVORK5CYII=" width="100%"></th>
  </tr>
  <tr class="DoDont_tr">
    <td class="Dont_td">Don't</td>
    <td class="divider"></td>
    <td class="Do_td">Do</t>
  </tr>
  <tr class="content">
    <td>Don't make a virtual object with the exact same size and shape with the real object. </td>
    <td class="divider"></td>
    <td>Make the position and shape of a virtual object unrelated to the real object.</t>
  </tr>
</table> -->

## 物体在进入场景时应该有一个可信的设定

在真实世界中，物体不会瞬间突然出现在世界里。因此，尝试让你的角色通过传送门、全息投影仪或其他有创造力的方式进入场景。好的第一印象会给整个体验的可信度加分。

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
  <label for="mce-EMAIL">我们在努力优化这份文档，👋欢迎订阅！  </label>
  <input type="email" value="" name="EMAIL" class="email" id="mce-EMAIL" placeholder="email address" required>
    <!-- real people should not fill this in and expect good things - do not remove this or risk form bot signups-->
    <div style="position: absolute; left: -5000px;" aria-hidden="true"><input type="text" name="b_98e146615feaa80a87c9e26a2_29c6a9379d" tabindex="-1" value=""></div>
    <div class="clear"><input type="submit" value="OK⏎" name="subscribe" id="mc-embedded-subscribe" class="button"></div>
    </div>
</form>
</div>

<!--End mc_embed_signup-->
