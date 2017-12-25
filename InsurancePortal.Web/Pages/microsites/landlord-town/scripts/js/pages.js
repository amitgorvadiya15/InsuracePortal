//displays a page - used for previous button and direct entering
function displayPage(page, movingMoreForward, animate_backgroundBack) {
	// determining, if prev/next buttons should be visible

	if (page != 'home') {
		$('#center, #number_buttons').css('visibility', 'visible');
	}

	aktualnaStrona = page;
	$('*').stop(true, true);

	hideSocialButtons();

	var display = 'block';

	if (page == 'home' || page == 'larry-wants-to-rent-his-house')
		display = 'none';

	$('#przycisk_prev, #przycisk_prev a').css('display', display);

	display = 'block';

	if (page == 'home' || page == 'the-end')
		display = 'none';

	$('#przycisk_nav, #przycisk_nav a').css('display', display);

	$('#animacja_larrego').css('display', 'block');

	display = 'block';

	if (page == 'home' || page == 'larry-wants-to-rent-his-house'
			|| page == 'pre-rental-checklist' || page == 'the-end'
			|| page == 'finding-tradesman' || page == 'gas-safety-checks'
			|| page == 'tax-on-rental-profits' || page == 'evicting-tenants')
		display = 'none';

	$('#animacja_larrego2').css('display', 'none');
	$('#animacja_larrego2').css('left', '690px');

	$('#larry_house').css('display', 'none');

	clearLastUpdate_2();

	var delay_time = 1;

	if (animate_backgroundBack) {
		delay_time = 2000;

		imageIndex = 1;
		prepareLarryBackwardWalking();
		updateAnim();

		animationBackward();
	}

	setTimeout(
			function() {

				if (page == aktualnaStrona) {

					if (page == 'larry-wants-to-rent-his-house') {
	
						playMode = 2;
						document.MainImage.src = 'layout/animation/larry_talking/larry_talking0022.png';

						playIntroSnd();

						$('#tekst_dialogu').css('display', 'block');


						$('#larry_house').css({
							'left' : '600px',
							'display' : 'block'
						});

					} else if (page == 'using-letting-agency') {
						$('#animacja_larrego').css('display', 'block');
						animacjaLarregoIVideo('video', false, movingMoreForward);

					} else if (page == 'pre-rental-checklist') {
				
						var delayTime = 1;

						if (movingMoreForward) {
							delayTime = 2000;

							imageIndex = 1;
							tworzZdjeciaDo1AnimacjiChodzenia();
							updateAnim();

							if (delayTime == 1)
								$('#center').animate({
									backgroundPosition : '-=400px 0px'
								}, delayTime);
							else
								animationForward();

						}

						timeOutId2 = setTimeout(
								function() {

									$('#checklist').css({
										'display' : 'block',
										'top' : '20px',
										'opacity' : '0'
									});
									$('#checklist').animate({
										top : '20px'
									}, 1);

									$('#checklist').animate({
										'opacity' : '1'
									}, 1000);
									$('#animacja_larrego').css('display',
											'block');

									clearLastUpdate();
									document.MainImage.src = 'layout/animation/larry_list/larry_list0070.png';
								
								}, delayTime);
					} else if (page == 'signing-tenancy-agreement') {
						animacjaLarregoIVideo('video2', false,
								movingMoreForward);
					} else if (page == 'getting-landlord-insurance') {
						uruchom_getting_landlord_insurance(false,
								movingMoreForward);
					} else if (page == 'finding-tradesman') {
						animacjaLarregoIVideo('video-' + page, false,
								movingMoreForward);
					} else if (page == 'gas-safety-checks') {

						animacjaLarregoIVideo('video-' + page, false,
								movingMoreForward);
					} else if (page == 'tax-on-rental-profits') {

						animacjaLarregoIVideo('video-' + page, false,
								movingMoreForward);
					} else if (page == 'evicting-tenants') {
						$('#finish_page').css('display', 'none');
						animacjaLarregoIVideo('video-' + page, false,
								movingMoreForward);
					} else if (page == 'the-end') {

						var delayTime = 1;

						if (movingMoreForward) {
							delayTime = 2000;

							imageIndex = 1;
							tworzZdjeciaDo1AnimacjiChodzenia();
							updateAnim();

							if (delayTime == 1)
								$('#center').animate({
									backgroundPosition : '-=400px 0px'
								}, delayTime);
							else
								animationForward();
						}

						timeOutId2 = setTimeout(
								function() {

									setTimeout(
											function() {
												$("#finish_page_fb")
														.hide()
														.html(
																'&nbsp;<div class="fb-like1" data-href="http://facebook.com/simply.business" data-send="false" data-layout="box_count" data-width="450" data-show-faces="true"></div>')
														.fadeIn('fast');
											}, 5000);

									$('#finish_page').css({
										'top' : '50px',
										'opacity' : '0',
										'display' : 'block'
									}).animate({
										'opacity' : '1'
									}, 2000);

									showSocialButtons('end');

									$('#larry_house').css({
										'left' : '690px',
										'display' : 'block',
										'opacity' : '0'
									});

									imageIndex_2 = 1;
									tworzZdjeciaDoAnimacji2_sp01_idle();
									updateAnim_2();

									$('#animacja_larrego2').css({
										'display' : 'block',
										'opacity' : '0',
										'left' : '840px'
									}).animate({
										opacity : '1'
									}, 2000);

									$('#larry_house').animate({
										opacity : '1'
									}, 2000);

									playMode = 1;
									tworzZdjeciaDoAnimacji_larry_celebrate();
									imageIndex = 0;
									updateAnim();
								}, delayTime);

					}
					else
					// if (page == 'home')
					{

						$('#number_buttons').css('visibility', 'hidden');

						if (!is_loaded) {
							open_home_page_after_loaded = true;

							$('#loading').css('display', 'block');
							$('#center').css('margin-top', '-501px');
						} else
							pokazStroneGlowna();

						$('#gorna_belka h1').html('Landlord Town');
						$('#number_buttons').css('visibility', 'hidden');

						aktualnaStrona = 'home';
					}

					displayProperBackgroundForNumberButtons();
				}
			}, delay_time);
}
