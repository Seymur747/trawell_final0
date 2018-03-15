$(document).ready(function(){
  $(".owl-carousel").owlCarousel();
});
var owl = $('.owl-carousel');
owl.owlCarousel({
    items:1,
    loop:true,
    margin:0,
  	autoplay:true,
	autoplayTimeout:3000,
	autoplayHoverPause:false,
    singleItem:true,
    animateOut: 'fadeOut',

    animateIn: 'fadeIn',
    transitionStyle:true,
    nav:true,

 navText : ['<i class="fa fa-angle-left" aria-hidden="true"></i>',
 '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
 		touchDrag:true

 	// slideOutDown:false,
  //   animateIn:true,
  //   items : 1, 
  //   itemsDesktop : true,
  //   itemsDesktopSmall : false,
  //   itemsTablet: false,
  //   itemsMobile : false


});

