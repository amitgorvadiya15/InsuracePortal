function prevBtnCLick() {
	$('*').stop(true, true);

	$(
			'#welcome_pageContainer,#scenka .video, #finish_page, #larry_house, #pytanie_larrego,#animacja_larrego2,animacja_larrego,#odpowiedz_lennego, #checklist, #checklist_tekst, #tekst_dialogu')
			.css('display', 'none');

	clearTimeout(nextBtnAnimTimeoutId);
	clearTimeout(timeOutId2);

	clearLastUpdate_2();

	pauseVideo();
	stopSound();

	var page_to_open = aktualnaStrona;

	imageIndex = 1;
	prepareLarryBackwardWalking();
	updateAnim();

	animationBackward(true);

	hideSocialButtons();

	setTimeout(function() {

		if (aktualnaStrona == page_to_open) {

			if (aktualnaStrona == 'the-end') {
				$('#przycisk_nav a').css('display', 'block');
				
				$('#finish_page').css('display', 'none');
				aktualnaStrona = 'evicting-tenants';
			
				displayPage(aktualnaStrona, false);

			} else if (aktualnaStrona == 'evicting-tenants') {
				$('#video-evicting-tenants').css('display', 'none');

				aktualnaStrona = 'tax-on-rental-profits';
			
				displayPage(aktualnaStrona, false);
			} else if (aktualnaStrona == 'tax-on-rental-profits') {
				$('#video-tax-on-rental-profits').css('display', 'none');

				aktualnaStrona = 'gas-safety-checks';

				displayPage(aktualnaStrona, false);
			} else if (aktualnaStrona == 'gas-safety-checks') {
				$('#video-gas-safety-checks').css('display', 'none');

				aktualnaStrona = 'finding-tradesman';

				displayPage(aktualnaStrona, false);
			} else if (aktualnaStrona == 'finding-tradesman') {
				$('#video-finding-tradesman').css('display', 'none');
				$('#pytania').css('display', 'block');

				aktualnaStrona = 'getting-landlord-insurance';
				displayPage(aktualnaStrona, false);

			} else if (aktualnaStrona == 'getting-landlord-insurance') {
				$('#pytania').css('display', 'none');
				aktualnaStrona = 'signing-tenancy-agreement';

				displayPage(aktualnaStrona, false);

			} else if (aktualnaStrona == 'signing-tenancy-agreement') {
				aktualnaStrona = 'pre-rental-checklist';

	
				stopSound();
				$('#video2').css('display', 'none');

				displayPage(aktualnaStrona, false);

				playMode = 2;

			} else if (aktualnaStrona == 'pre-rental-checklist') {
				playMode = 1;

				aktualnaStrona = 'using-letting-agency';

				$('#checklist').css('top', '500px');
				$('#checklist_tekst').css('display', 'none');

			
				stopSound();
				displayPage(aktualnaStrona, false);

				$('#przycisk_prev a').css('display', 'block');
			} else if (aktualnaStrona == 'using-letting-agency') {
				aktualnaStrona = 'larry-wants-to-rent-his-house';
				$('#video').css('display', 'none');

				displayPage(aktualnaStrona, false);

				$('#przycisk_prev a').css('display', 'none');
			} else if (aktualnaStrona == 'larry-wants-to-rent-his-house') {
				aktualnaStrona = 'using-letting-agency';
				displayPage(aktualnaStrona, false);
			}

			$('#gorna_belka h1').html(getPageTitle(aktualnaStrona));
			displayProperBackgroundForNumberButtons();

			var display = 'block';

			if (aktualnaStrona == 'home' || aktualnaStrona == 'the-end'
					|| aktualnaStrona == 'larry-wants-to-rent-his-house'
					|| aktualnaStrona == 'pre-rental-checklist')
				display = 'none';

			$('#animacja_larrego2').css('display', display);

			display = 'none';

			if (aktualnaStrona == 'getting-landlord-insurance'
					|| aktualnaStrona == 'the-end')
				display = 'block';

			$('#animacja_larrego2').css('display', display);
		}

	}, 2000);

}