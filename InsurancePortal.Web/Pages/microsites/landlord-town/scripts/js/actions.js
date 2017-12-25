
function uruchom_getting_landlord_insurance(przod, movingMoreForward) {

	pauseVideo();


	clearLastUpdate_2();
	document.MainImage_2.src = 'layout/animation/sb_talking/sb_talking0001.png';

	$('#animacja_larrego2').css('display', 'none');
	$('#pytania').css('display', 'block');

	$('#animacja_larrego').css('display', 'block');


	aktualnieZadanePytanieLarrego = 0;

	if (przod || movingMoreForward) {
		aktualnieWyswietlanaAnimacja = 'larry_cycle';
		imageIndex = 1;
		tworzZdjeciaDo1AnimacjiChodzenia();
		updateAnim();

	}

	if (przod || movingMoreForward) {

		animationForward();

		setTimeout(function() {

			if (aktualnaStrona == 'getting-landlord-insurance') {
				
				clearLastUpdate();
				document.MainImage.src = 'layout/animation/larry_talking/larry_talking0102.png';
				
				setTimeout(function(){											
					imageIndex = 1;
					tworzZdjeciaDoAnimacji_larry_taking13();
					updateAnim();
				},1000);


				next_odpowiedz_lennego();

				setTimeout(function() {
					$('#animacja_larrego2').css('display', 'block');
				}, 100);

			}
		}, 2000);
		
		aktualnieZadanePytanieLarrego = 0;

	} else {

		aktualnieZadanePytanieLarrego = 0;

		if (!movingMoreForward || 1 == 1) {
			
			clearLastUpdate();
			document.MainImage.src = 'layout/animation/larry_talking/larry_talking0102.png';
			
			setTimeout(function(){											
					imageIndex = 1;
					tworzZdjeciaDoAnimacji_larry_taking13();
					updateAnim();
			},1000);
				

			next_odpowiedz_lennego(movingMoreForward);

		}

	}

}

function zwrocZnakPrzesuniecia(przod) {
	if (przod)
		return '-';
	else
		return '+';
}

function zamknij_tekst_checklisty() {

	// stop audio

	$('#checklist_tekst').animate({
		opacity : '0'
	}, 1500, function() {
		$(this).css('display', 'none');
	});

	$('#checklist').animate({
		top : '50'
	}, 2000);

	stopSound();

}

function landingPageBeginClick() {
	setStaticArrow();
	cleanAfterLandingPage();
	hideSocialButtons();

	playIntroSnd();

	$('#tekst_dialogu').css('display', 'block');

	$('#scenka_home').css('display', 'none');

	$('#scenka').css({
		'display' : 'block',
		'opacity' : '0'
	}).animate({
		'opacity' : '1'
	}, 1000);

	$('#przycisk_prev').css('display', 'none');
	$('#przycisk_nav, #przycisk_nav a').css('display', 'block');

	$('#animacja_larrego').css('display', 'block');

	aktualnaStrona = 'larry-wants-to-rent-his-house';

	$('#larry_house').css({
		'left' : '600px',
		'display' : 'block'
	});

	playMode = 2;

	document.MainImage.src = 'layout/animation/larry_talking/larry_talking0022.png';
	displayProperBackgroundForNumberButtons();

}

function cleanAfterLandingPage() {

	$('#szareTlo') 
	.css('display', 'none');

	$('#szareTlo2').css('backgroundColor', '#fff')

	$('#welcome_page, #welcome_pageContainer').css('display', 'none');

	$('#animacja_larrego3').css('display', 'none');
}

function nextBtnCLick() {

	$(
			'#welcome_pageContainer, #scenka .video, #finish_page, #pytanie_larrego, #odpowiedz_lennego, #checklist, #checklist_tekst, #tekst_dialogu, #larry_house')
			.css('display', 'none');
	$('#animacja_larrego').css('display', 'block');

	// clearing timeout

	clearTimeout(nextBtnAnimTimeoutId);
	clearTimeout(timeOutId2);


	$('#przycisk_prev').css('display', 'block');

	$('*').stop(true, true);
	pauseVideo();
	stopSound();

	$('#animacja_larrego2').css('left', '690px');

	if (aktualnaStrona == 'larry-wants-to-rent-his-house') {
		
		// play video
		// play no 1 movie
		$('#tekst_dialogu').css('display', 'none');
		$('#animacja_larrego2').css('display', 'none');


		aktualnaStrona = 'using-letting-agency';

		animacjaLarregoIVideo('video', true, false);

		// walking
		aktualnieWyswietlanaAnimacja = 'chodzenie';
		tworzZdjeciaDo1AnimacjiChodzenia();
		imageIndex = 0;
		updateAnim();

	

		$('#przycisk_prev a').css('display', 'block');

	} else if (aktualnaStrona == 'using-letting-agency') {
		// checkboxs listing
		// walking

		pauseVideo();

		imageIndex = 0;
		tworzZdjeciaDo1AnimacjiChodzenia();
		updateAnim();
	
		$('#video').css('display', 'none');

	
		animationForward();
		
		setTimeout(function() {
			
			if (aktualnaStrona == 'pre-rental-checklist') {

				imageIndex = 0;
				tworzZdjeciaDoAnimacji_larry_list();
				updateAnim();

				aktualnieWyswietlanaAnimacja = 'larry_list';

				$('#checklist').css({
					'display' : 'block',
					'top' : '500px'
				}).animate({
					top : '20px'
				}, predkosc_wysuwania_checklist, function() { 
				});

				// there is next action in animImageInc 
			}
		}, 2000);

		aktualnaStrona = 'pre-rental-checklist';

	} else if (aktualnaStrona == 'pre-rental-checklist') {

		playMode = 1;
		// checklist rolling out, animation video

		aktualnaStrona = 'signing-tenancy-agreement';
		$('#animacja_larrego2').css('display', 'none');

		$('#animacja_larrego').css('display', 'block');
		imageIndex = 1;
		aktualnieWyswietlanaAnimacja = 'larry_list_chowa';
		tworzZdjeciaDoAnimacji_larry_list_chowa();
		updateAnim();

		$('#checklist_tekst').css('display', 'none');

		stopSound();
		$('#checklist').animate({
			top : '500px'
		}, predkosc_chowania_checklist, function() {
			
		});
		// following actions in

	} else if (aktualnaStrona == 'signing-tenancy-agreement') {
		//shwoing questions
		$('#MainImage_2').attr('src',
				'layout/animation/sb_talking/sb_talking0001.png');

		document.MainImage_2.src = 'layout/animation/sb_talking/sb_talking0001.png';

		uruchom_getting_landlord_insurance(true, false);
		$('#video2').css('display', 'none');
		$('#animacja_larrego2').css('opacity', '0');

		aktualnaStrona = 'getting-landlord-insurance';

	} else

	if (aktualnaStrona == 'getting-landlord-insurance')
	{
		$('#pytania').css('display', 'none');
		stopSound();

		aktualnieWyswietlanaAnimacja = 'larry_cycle';
		aktualnaStrona = 'finding-tradesman';
		animacjaLarregoIVideo('video-finding-tradesman', true);

	
	} else if (aktualnaStrona == 'finding-tradesman') {
		$('#video-finding-tradesman').css('display', 'none');
		aktualnaStrona = 'gas-safety-checks';
		animacjaLarregoIVideo('video-' + aktualnaStrona, true, false);
	} else if (aktualnaStrona == 'gas-safety-checks') {
		$('#video-gas-safety-checks').css('display', 'none');
		aktualnaStrona = 'tax-on-rental-profits';
		animacjaLarregoIVideo('video-' + aktualnaStrona, true, false);
	} else if (aktualnaStrona == 'tax-on-rental-profits') {
		$('#video-tax-on-rental-profits').css('display', 'none');
		aktualnaStrona = 'evicting-tenants';
		animacjaLarregoIVideo('video-' + aktualnaStrona, true, false);
	} else

	if (aktualnaStrona == 'evicting-tenants') {
		$('#video-evicting-tenants').css('display', 'none');
		$('#przycisk_nav a').css('display', 'none');

		$('#larry_house').css({
			'display' : 'block',
			'opacity' : '0'
		});
		$('#larry_house').css('left', '690px');

		aktualnaStrona = 'the-end';

		imageIndex = 0;
		tworzZdjeciaDo1AnimacjiChodzenia();
		updateAnim();
		aktualnieWyswietlanaAnimacja = 'larry_walking';


		animationForward();

	}

	// getNextPagesLink('s');
	$('#gorna_belka h1').html(getPageTitle(aktualnaStrona));

	displayProperBackgroundForNumberButtons();
	// alert('dsdsd');
	var display = 'block';

	// alert('next '+aktualnaStrona);
	if (aktualnaStrona == 'home'
			|| aktualnaStrona == 'larry-wants-to-rent-his-house'
			|| aktualnaStrona == 'pre-rental-checklist'
			|| aktualnaStrona == 'the-end'
			|| aktualnaStrona == 'signing-tenancy-agreement')// only fo
																// nextClic
		display = 'none';

	display = 'none';

	if (aktualnaStrona == 'getting-landlord-insurance'
			|| aktualnaStrona == 'the-end')
		display = 'block';

	$('#animacja_larrego2').css('display', display);
}

// using number buttons
function changeCurrentPage(page) {
	$('*').stop(true, true);

	clearTimeout(nextBtnAnimTimeoutId);
	clearTimeout(timeOutId2);

	$('#scenka_home').css('display', 'none');
	$('#animacja_larrego3').css('display', 'none');
	$('#animacja_larrego2').css('display', 'none');

	$('#welcome_pageContainer').css('display', 'none');
	$('#szareTlo').css('display', 'none');
	$('#szareTlo2').css('backgroundColor', '#fff');

	$('#scenka').css('display', 'block');

	var current_number = getPageNumber(aktualnaStrona);
	var found_previous_page = false;

	pauseVideo();
	stopSound();

	$(
			'#welcome_pageContainer,#scenka .video, #finish_page, #pytanie_larrego, #odpowiedz_lennego, #checklist, #checklist_tekst, #tekst_dialogu')
			.css('display', 'none');

	if (aktualnaStrona == 'home')
		cleanAfterLandingPage();

	if (current_number > 1)// 1 is the first page's index
	{

		if (available_sites[current_number - 1][0] == page) {
			
			// one has to store next's pages url in order to get back
			aktualnaStrona = available_sites[current_number][0];
			found_previous_page = true;

			if (aktualnaStrona != 'larry-wants-to-rent-his-house')
				prevBtnCLick();
		}
	}

	if (!found_previous_page && (current_number < available_sites.length - 1)) {

		if (aktualnaStrona != 'home'
				&& available_sites[current_number + 1][0] == page) {
			
			aktualnaStrona = available_sites[current_number][0];

			if (aktualnaStrona == 'home'
					&& page == 'larry-wants-to-rent-his-house')
				landingPageBeginClick();
			else
				nextBtnCLick();

			found_previous_page = true;

		}
	}

	if (!found_previous_page) {
	

		displayProperBackgroundForNumberButtons();


		if (aktualnaStrona == 'home' && page == 'larry-wants-to-rent-his-house')
			landingPageBeginClick();
		else {
			// moving larry


			var nextPage = getPageNumber(page)

			var animateBackBackground = false;

			if (nextPage < current_number)
				animateBackBackground = true;

			displayPage(page, nextPage > current_number, animateBackBackground);

		}
	}

}

function displayProperBackgroundForNumberButtons() {

	if (aktualnaStrona != 'home')
		$('#szareTlo2').css('display','none');

	var i;
	var img;
	for (i = 1; i <= 10; i++) {
		if (aktualnaStrona == available_sites[i + 1][0])
			img = '_hov';
		else
			img = '';

		$('#number_button_' + i).css('background-image',
				'url(layout/number_button/' + i + img + ".png)");

	}

	// display proper underline in the left column
	$('.kolor a').css('text-decoration', 'none');
	$('#' + aktualnaStrona + "_ba").css('text-decoration', 'underline');

	var display = 'visible';

	if (aktualnaStrona == 'home')
		display = 'hidden';

	$('#number_buttons').css('visibility', display);

	// and next btn

	var btn = 'next_btn.html';

	if (aktualnaStrona == 'larry-wants-to-rent-his-house')
		setTimeout(function() {
			setBlinkingArrow()
		}, 17000);

	$('#przycisk_nav a').css('background-image', "url('layout/" + btn + "')");
	
	
}

function hideSocialButtons() {
	$('#social_buttons').css('top', '-500px');
}

function showSocialButtons(site) {
	var left;
	var top;
	var time;

	if (site == 'home') {
		left = '366px';
		top = '400px';
		time = 3000;
	} else {
		left = '396px';
		top = '344px';
		time = 3000;
	}

	setTimeout(function() {

		$('#social_buttons').css({
			'visibility' : 'visible',
			'opacity' : '0',
			'left' : left,
			'top' : top
		});

		setTimeout(function() {
			$('#social_buttons').animate({
				'opacity' : '1'
			}, time);
		}, 100);

	}, 200);
}

function showHomePage() {
	pauseVideo();
	stopSound();

	hideSocialButtons();

	$('#scenka_home').css('display', 'block');
	$('#scenka').css('display', 'none');

	$('#animacja_larrego3').css('display', 'block');

	$('#welcome_pageContainer').css({
		marginTop : '-10px'
	});
	$('#welcome_page').css({
		'margin-top' : '500px',
		'height' : '1px',
		'display' : 'block'
	});

	$('#welcome_page').animate({
		marginTop : '20px',
		height : '512px'
	}, 2000, function() {
		showSocialButtons('home');
	});

	$('#welcome_pageContainer').css('display', 'block');

	$('#szareTlo').css({
		'display' : 'block'
	}); 
	$('#szareTlo2').css({
		'background-color' : '#999999'
	});

	$(
			'#scenka .video, #finish_page, #pytanie_larrego, #odpowiedz_lennego, #checklist, #checklist_tekst, #tekst_dialogu')
			.css('display', 'none');

	aktualnaStrona = 'home';

	displayProperBackgroundForNumberButtons();

	tworzZdjeciaDoAnimacji3_big_larry();
	imageIndex_3 = 0;
	updateAnim_3();
}

// /left/ right arrow
$('*').on(
		'keydown',
		function(e) {

			var key = e.which;
			// 37 - left ; 39 right

			if (key == 39) {
				if (aktualnaStrona != 'home' && aktualnaStrona != 'the-end')
					nextBtnCLick();
			} else if (key == 37) {
				if (aktualnaStrona != 'home'
						&& aktualnaStrona != 'larry-wants-to-rent-his-house')
					prevBtnCLick();
			}

		});