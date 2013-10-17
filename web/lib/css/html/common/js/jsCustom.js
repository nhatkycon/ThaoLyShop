// Call back jcarousel
function mycarousel_initCallback(carousel){
    // Disable autoscrolling if the user clicks the prev or next button.
    carousel.buttonNext.bind('click', function(){carousel.startAuto(0);});
    carousel.buttonPrev.bind('click', function(){carousel.startAuto(0);});
    // Pause autoscrolling if the user moves with the cursor over the clip.
    carousel.clip.hover(function(){carousel.stopAuto();}, function(){carousel.startAuto();});
};
/* JS Custom */
$(document).ready(function(){
	// GNB
	$('#navMain .nav > li').has('ul').addClass('hasUl').find('> a').addClass('parent');
	var indexstart = $('#navMain .nav li.navHover').index();
	$('#navMain .nav > li').hover(
		function(){
			if($(this).index() != indexstart){
				$('#navMain .nav > li').removeClass('navHover');
				$(this).stop().addClass('navHover');
			}
		},
		function(){
			$(this).removeClass('navHover');
			$('#navMain .nav > li').eq(indexstart).stop().addClass('navHover');
		}
	);
	/*$('#navMain .nav > li').hoverIntent({
		interval:50,
		timeout:50,
		over:function(){if($(this).index() != indexstart){$('#navMain .nav > li').removeClass('navHover');$(this).stop().addClass('navHover');}},
		out:function(){$(this).removeClass('navHover');$('#navMain .nav > li').eq(indexstart).stop().addClass('navHover');}
	});*/
	
	// Selectbox
	$('.selectbox .select').selectbox();
	
	// Slides home page
	$('.box_skitter').skitter({animation:'blind', interval:4000, navigation:false, numbers: false, preview:true });
	
	// idTabs
	$('.tabMain .tab').idTabs();
	
	// jcarousel
	$('.mycarousel .jch_ls').jcarousel({
		auto: 1,
		scroll: 1,
		animation: 800,
		wrap: 'last',
		initCallback: mycarousel_initCallback
    });
	
	// Change larger image
	$('.galery .thumb_ls li').bind('click', function(){  
		$('.galery .thumb_ls li').removeClass('active');
		$(this).addClass('active');
		$('.galery .thumb > img').attr('src', $(this).find('> a').attr('data-larger-image'));
		return false;
	});
	
});