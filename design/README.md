# Introduction

MR (Mixed Reality) techonology is going to change the way we compute. It is very powerful but can be challenging to get right since there are a lot of unknowns.

[Ximmerse](https://www.ximmerse.com) specialized in MR technology as well as design research. We develop experiences for Rhino X in house and are constantly experimenting with new ways to use MR technology.

With years of R&D and lots of trial and errors, we have condensed our learnings down into these design guidelines. We are also creating tools like *Mixed Reality Playground* and *MRITK(MR Interaction Toolkit)*, so that you can see these guidelines in action and actually use our code to build them. So stay tuned for updates.

## What's special about Rhino X
Most MR headsets have fairly limited fov(field of view), the 50°(horizontal) x 57°(vertical) fov of Rhino X can give you an immersive MR experience. Ximmerse also created X-tag tracking technology which can provide robust tracking for any objects, providing richer interaction opportunities.

## Why these design guidelines
All major MR companies have their design guidelines, and this document is not a sum up of other company's work. All the findings here are based on our own research. We want to give back the design community with our own unique insights.
Guidelines on [illusion](/illusion), [color](/interface?id=our-study-for-rhino-x), [eye space UI](/interface?id=eye-space-ui-standard) and [far field interaction techniques](/interaction?id=far-field-grabbing-techniques-zoom-grab-and-portal-grab) are all novel contributions to the commnunity.

## What is MR? Why it's different from VR or AR?
There are a lot of buzzwords around technology, like VR, AR, XR, Spatial Computing etc. 
Below is a short video explaining these buzzwords:

<iframe width="100%" height="300" src="https://www.youtube.com/embed/TjsIyDn5H44" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

Our definition of MR is an optical-see-through stereo HMD(Head Mounted Display) with 6 DoF(Degree of Freedom) headtracking at least. Magic Leap One, HoloLens and Rhino X all fall into this category.

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
  <label for="mce-EMAIL">This page is under constant improvement. 👋 Subscribe to future updates! </label>
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