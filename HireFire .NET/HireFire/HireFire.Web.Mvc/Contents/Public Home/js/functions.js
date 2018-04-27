(function ($) {
	
	//jQuery for page scrolling feature - requires jQuery Easing plugin
	$(function() {
		$('.navbar-nav li a').bind('click', function(event) {
			var $anchor = $(this);
			var nav = $($anchor.attr('href'));
			if (nav.length) {
			$('html, body').stop().animate({				
				scrollTop: $($anchor.attr('href')).offset().top				
			}, 1500, 'easeInOutExpo');
			
			event.preventDefault();
			}
		});
						
	});	
	
	$('body').flipLightBox({
			
		lightbox_text_status: 0,
		lightbox_navigation_status: 0
    
	})
	
	$('.parallax-window').parallax({imageSrc: 'img/3.png'});
	
		

})(jQuery);

