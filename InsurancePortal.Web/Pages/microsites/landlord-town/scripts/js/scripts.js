
function pokazStroneGlowna() {

	$('#szareTlo').css('display', 'block');
	$('#szareTlo2').css({
		'background-color' : '#999999'
	});

	$('#animacja_larrego, #animacja_larrego2').css('display', 'none');
	$('#welcome_pageContainer').css('display', 'block');

	$('#scenka_home').css('display', 'block');
	$('#scenka').css('display', 'none');

	$('#center, #number_buttons').css('visibility', 'visible');

	$('#animacja_larrego3').css({
		'display' : 'block',
		'opacity' : '0'
	}).animate({
		'opacity' : '1'
	}, function() {
		tworzZdjeciaDoAnimacji3_big_larry();
		imageIndex_3 = 0;
		updateAnim_3();
	});
	
	$('#welcome_pageContainer').css({
		marginTop : '-10px'
	});

	$('#welcome_page').css({
		'margin-top' : '500px',
		'height' : '1px'
	});

	$('#welcome_page').animate({

		marginTop : '20px',
		height : '512px'
	}, 2000, function() {
		// Animation complete.
		// for IE

		showSocialButtons('home');

	});

	displayProperBackgroundForNumberButtons();

	$('#gorna_belka h1').html(getPageTitle(aktualnaStrona));
}

var images = new Array();
// id, left, top

images[0] = new Array('background', 235, 121);
images[1] = new Array('cloud1', 146, 91);
images[2] = new Array('cloud2', 395, 20);
images[3] = new Array('cloud3', 760, 70);


images[4] = new Array('cloud4', 1160, 65);
images[5] = new Array('house1', 575, -260);
images[6] = new Array('house2', 870, 272);
images[7] = new Array('house3', 1146, 137);
images[8] = new Array('house4', 1490, 220);
// images[9] = new Array('mountain',16,180);

images[9] = new Array('mountain1', 5, 183);
images[10] = new Array('tree1', 210, 264);
images[11] = new Array('tree2', 356, 192);
images[12] = new Array('tree3', 724, 250);
images[13] = new Array('tree4', 788, 270);
images[14] = new Array('tree5', 1030, 240);
images[15] = new Array('tree6', 1395, 243);
images[16] = new Array('tree7', 1664, 240);



images[17] = new Array('mountain2', 614, 243);
images[18] = new Array('mountain3', 942, 230);
images[19] = new Array('mountain4', 1340, 180);
images[20] = new Array('mountain5', 1665, 180);

function arrangeImages() {

	for ( var i = 0; i < images.length; i++) {
		$('#' + images[i][0]).css({
			'left' : images[i][1],
			'top' : images[i][2]
		});
	}

}
/*
 * var cloud_move = 200; var mountain_move = 400; var tree_move = 600; var
 * house_move = 800;
 */

var cloud_move = 150;
var mountain_move = 250;
var tree_move = 450;
var house_move = 650;

function animationForward() {
	
	try {
		animateBackground(true);
	} catch (e) {}

	
	if (BrowserDetect.browser == 'Explorer') 
		animateBackground(true);
}

function animationBackward(notacceptTheEnd) {
	try {
		animateBackground(false, notacceptTheEnd);
	} catch (err) {	}
	
	if (BrowserDetect.browser == 'Explorer') 
		animateBackground(false, notacceptTheEnd);

}

function animateBackground(forward, notacceptTheEnd) {


	for ( var i = 0; i < images.length; i++) {
		var type = images[i][0].substring(0, 1);

		if (forward) {
			if (images[i][1] + $('#' + images[i][0]).width() < 0) {

				images[i][1] += 2144;
				$('#' + images[i][0]).css({
					'left' : images[i][1]
				});
			}
			
		} else {
			if (images[i][1] > 960) {

				images[i][1] = -(2144 - images[i][1] - $('#' + images[i][0])
						.width());
			
				$('#' + images[i][0]).css({
					'left' : images[i][1] + 'px'
				});

			}

		}

		var movement;

		if (type == 'c') {
			movement = cloud_move;
		} else if (type == 'm') {
			movement = mountain_move;
		} else if (type == 't') {
			movement = tree_move;
		} else if (type == 'h') {
			movement = house_move;
		}

		if (!forward)
			movement = -movement;

		if (aktualnaStrona == 'the-end' && !notacceptTheEnd)
			movement *= (35 / 20);

		images[i][1] -= movement;

		var time = 2000;

		if (aktualnaStrona == 'the-end' && !notacceptTheEnd)
			time = 3500;
		// % 980 % 1600
		$('#' + images[i][0]).animate({
			'left' : images[i][1]
		}, time);
		
	}

}

$(window).ready(function() {

	arrangeImages();

	var file = 'checkbox.css';

	if (BrowserDetect.browser == 'Explorer') {

		if (BrowserDetect.version < 9)
			file = 'checkbox_ie.css';
	}

	$("head").append("<link>");
	css = $("head").children(":last");
	css.attr({
		rel : "stylesheet",
		type : "text/css",
		href : file
	// "checkbox.css"
	});

});

$(window)
		.load(
				function() {
	
					is_loaded = true;

					if (open_home_page_after_loaded) {
						$('#loading').css('display', 'none');
						$('#center').css('margin-top', '-1px');

						open_home_page_after_loaded = false;
						pokazStroneGlowna();
					}

					// checkbox on list click
					$('#checklist_form input')
							.click(
									function() {
										var klikniety_item = $(this).attr('id');
										var stan = $('#' + klikniety_item).is(
												':checked');

										var font = 'normal';
										if (stan)
											font = 'bold';

										$('#' + klikniety_item + ' + p').css(
												'font-weight', font);

										if (stan) {

											$('#checklist_tekst').css({
												'display' : 'block',
												'opacity' : '0'
											}).animate({
												opacity : '1'
											}, 2000);

											$('#checklist').animate({
												top : '500px'
											}, 2000);

											var czytany_tekst;
											var teksty = new Array();
											teksty['property_scratch'] = new Array(
													'Carry out necessary maintenance before you start viewings. Make sure that your property meets key legal requirements, including the Gas Safety Regulations 1998, and the Electrical Equipment and Safety Regulations.',
													1);
											teksty['mortgage_company'] = new Array(
													'It’s vital that you do this before you start renting. Some companies don’t allow rentals, while others will place restrictions on your rental activities.',
													2);
											teksty['landlord_registration'] = new Array(
													'In some areas, including Scotland and Newham, you’re required to register with your local authority, although calls for nationwide landlord registration are growing. ',
													3);
											teksty['tenants_ability'] = new Array(
													'A good letting agency will perform the relevant checks for you. If you’re doing it yourself, checks might involve confirming tenants’ employment status and carrying out a credit check with a major credit reference agency such as Experian or Equifax.',
													4);
											teksty['referenece_guarantors'] = new Array(
													'References are one of the most important tools available to landlords. Seek references from previous landlords and from employers and check them carefully.',
													5);
											teksty['protect_deposit'] = new Array(
													'If you are taking a security deposit, you are legally required to protect it in one of the three government-backed deposit schemes: the Deposit Protection Service, MyDeposits, or the Tenancy Deposit Scheme. ',
													6);
											teksty['make_inventory'] = new Array(
													'Before your tenants move in, list all the items that are in the property, noting any existing damage and taking supporting photos.',
													7);
											teksty['information_pack'] = new Array(
													'A pack should include basic details like the location of the stopcock and operation of the boiler. Well-informed tenants are amongst your best defences against disaster. ',
													8);
											teksty['redirect_mail'] = new Array(
													'Make sure that your mail is redirected to the relevant address. You can do this reasonably cheaply by contacting Royal Mail, and it will help to minimise the risk of identity theft.',
													9);
											teksty['inform_council'] = new Array(
													'Make sure that you tell the council whenever new tenants have moved in. They will then make contact with the tenants to ensure that the council tax is being paid.',
													10);
											teksty['stay_touch'] = new Array(
													'Finally, remember that renting is an ongoing process. By staying in regular contact with your tenants you can help to ensure that potential problems are headed off well in advance. ',
													11);

											// change text

											$('#checklist_tekst p').html(
													teksty[klikniety_item][0]);

											// read
									
											czytany_tekst = 'sounds/checklist/bullet-'
													+ teksty[klikniety_item][1]
													+ '-answer';// .ogg';
											playSound(czytany_tekst);
	
										}

										// blinking after all checked

										var checked_count = 0;

										$("#checklist_form input").each(
												function() {
													if ($(this).is(':checked'))
														checked_count++;
												});

										if (checked_count >= 11)
											setBlinkingArrow();

									});

					// closing  checklist

				});

var snd;

HTMLAudioElement.prototype.stop = function() {
	this.pause();
	this.currentTime = 0.0;
}

function stopSound() {

	try {
		snd.stop();
		
	} catch (error) {
	}
}

function playSound(soundfile) {

	if (window.HTMLAudioElement) {

		snd = new Audio();

		if (snd.canPlayType('audio/ogg')) {
			snd = new Audio(soundfile + '.ogg');
		} else if (snd.canPlayType('audio/mp3')) {
			snd = new Audio(soundfile + '.mp3');
		}

		snd.play();

	} else {
		// alert('HTML5 Audio is not supported by your browser!');
		/*
		 * document.getElementById("dummy").innerHTML= "<embed
		 * src=\""+soundfile+"\" hidden=\"true\" autostart=\"true\"
		 * loop=\"false\" />";
		 */
	}
}



var is_loaded = false;
var open_home_page_after_loaded = false;

var predkosc_wysuwania_checklist = 2200;
var predkosc_chowania_checklist = 4000;

var beginPlayingVideo_timerid;

function beginPlayingVideo(video) {
	playVideo(video);
	clearInterval(beginPlayingVideo_timerid);
}

// movingMoreForward - more than one scenes - larry's move animation
function animacjaLarregoIVideo(video, przod, movingMoreForward) {

	pauseVideo();

	imageIndex = 0;
	tworzZdjeciaDo1AnimacjiChodzenia();
	updateAnim();

	// w którą stronę przesuwać tło
	var kierunek = '+';

	// to play the video from start
	var html = $('#' + video).html();
	$('#' + video).html(html);

	var current_video_page = aktualnaStrona;

	if (przod) {
		$('#animacja_larrego2').css('opacity', '0');


		animationForward();

		setTimeout(function() {

			if (aktualnaStrona == current_video_page) {

				// chodzenie do checklista
				if (1 == 1)
				{

					imageIndex = 1;
					aktualnieWyswietlanaAnimacja = 'larry_idle';
					tworzZdjeciaDo1AnimacjiLarryIdle();
					updateAnim();
				}

				// alert('przod 3');
				// 2. ludzik
				imageIndex_2 = 1;
				pokazLudzikaPrzyVideo();
				updateAnim_2();

				// after finishing walking

				$('#animacja_larrego2').css({
					'display' : 'none'
				});

				// *
				timeOutId2 = setTimeout(function() {


					$('#' + video).css({
						'display' : 'block',
						'opacity' : '0'
					});
					$('#' + video).animate({
						opacity : '1'
					}, 2000, function() {

						setTimeout(function() {

							if (aktualnaStrona == current_video_page)
								playVideo('#' + video);
						}, 100);

					});
				}, 200);

			}

		}, 2000);
	} else {

		// + jumping more than 1 scene; movingMoreForward - back or forward

		$('#animacja_larrego2').css('opacity', '0');

		if (movingMoreForward)
			animationForward();
		else
			$('#center').css({
				backgroundPosition : '-=400px 0px'
			});

		imageIndex_2 = 1;
		pokazLudzikaPrzyVideo();
		updateAnim_2();

		if (!movingMoreForward) {
			imageIndex = 1;
			tworzZdjeciaDo1AnimacjiLarryIdle();
			updateAnim();
		}

		var delayTime = 1;

		if (movingMoreForward)
			delayTime = 2000;

		timeOutId2 = setTimeout(function() {

			if (movingMoreForward) {
				imageIndex = 1;
				tworzZdjeciaDo1AnimacjiLarryIdle();
				updateAnim();
			}

			if (movingMoreForward)
				delayTime = 200;

			setTimeout(function() {

				$('#animacja_larrego2').css({
					'display' : 'none'
				});

				$('#' + video).css({
					'display' : 'block',
					'opacity' : '0'
				});
				$('#' + video).animate({
					opacity : '1'
				}, 2000, function() {

					setTimeout(function() {

						if (aktualnaStrona == current_video_page)
							playVideo('#' + video);
					}, 100);

				});

			}, delayTime);

		}, delayTime);

	}

	// blinking button

	var time;

	if (video == 'video')
		time = 54;
	else if (video == 'video2')
		time = 61;
	else if (video == 'video-finding-tradesman')
		time = 78;
	else if (video == 'video-gas-safety-checks')
		time = 37;
	else if (video == 'video-tax-on-rental-profits')
		time = 82;
	else if (video == 'video-evicting-tenants')
		time = 98;

	nextBtnAnimTimeoutId = setTimeout(setBlinkingArrow, (time + 2) * 1000);

}

function pokazLudzikaPrzyVideo() {
	if (aktualnaStrona == 'finding-tradesman')
		tworzZdjeciaDoAnimacji2_sp04_idle();
	else if (aktualnaStrona == 'gas-safety-checks')
		tworzZdjeciaDoAnimacji2_sp03_idle();
	else if (aktualnaStrona == 'tax-on-rental-profits')
		tworzZdjeciaDoAnimacji2_sp05_idle();
	else if (aktualnaStrona == 'evicting-tenants')
		tworzZdjeciaDoAnimacji2_sp04_idle()
	else if (aktualnaStrona == 'signing-tenancy-agreement')
		tworzZdjeciaDoAnimacji2_sp01_idle()
	else if (aktualnaStrona == 'larry-wants-to-rent-his-house')
		tworzZdjeciaDoAnimacji_sp02_idle()
	else if (aktualnaStrona == 'pre-rental-checklist')
		tworzZdjeciaDoAnimacji2_sp01_idle()
	else if (aktualnaStrona == 'using-letting-agency')
		tworzZdjeciaDoAnimacji_sp02_idle();
}


var aktualnaStrona = 'home';
var aktualnieZadanePytanieLarrego = 0;

var timeoutValue = 100;
var animDelay = 100;
var numOfImages = 126;

var imageIndex = 0;
var timeoutID = 0;
var playMode = 1;

var nextBtnAnimTimeoutId; // for blinking; needed to be cleared after moving
							// to another page
var timeOutId2; // for another animations

var timeoutValue_2 = 100;
var animDelay_2 = 100;
var numOfImages_2 = 126;

var imageIndex_2 = 0;
var timeoutID_2 = 0;
var playMode_2 = 1;

var timeoutID_3 = 0;

var aktualnieWyswietlanaAnimacja = '';

var animationsCircleCounter = 0;// counts how many times a nimataion was already
								// repeated
var animationsCircleCounter_2 = 0;
var gli_is_takling = '';// getting-landlord-insurance

function pokazDialogLarrego() {

}

function przygotujAnimacje() {

}

function playIntroSnd() {
	playSound('sounds/larry-intro');

}

function next_odpowiedz_lennego2() {
	aktualnieZadanePytanieLarrego = 2;
	next_odpowiedz_lennego();
}

var answersTimeOut;

function next_odpowiedz_lennego(movingMoreForward) {

	if (aktualnaStrona == 'getting-landlord-insurance') {

		gli_is_takling = 'larry';


		aktualnieZadanePytanieLarrego++;

		if (aktualnieZadanePytanieLarrego <= 0)
			aktualnieZadanePytanieLarrego = 1;

		var pytania = new Array();
		pytania[1] = 'What does landlord insurance cover? ';
		pytania[2] = 'What are the most important landlord covers?';
		pytania[3] = 'How much does a policy cost?';
		pytania[4] = 'Where can I buy landlord insurance?';

		var delayTime = 1;

		if (movingMoreForward) {
			delayTime = 2000;

			imageIndex = 1;
			tworzZdjeciaDo1AnimacjiChodzenia();
			updateAnim();

			if (delayTime == 1)
				animationForward();
		}

		nextBtnAnimTimeoutId = setTimeout(function() {

			$('#pytanie_larrego').css({
				'display' : 'block',
				'opacity' : '0'
			}).animate({
				'opacity' : '1'
			});

			$('#odpowiedz_lennego').animate({
				'opacity' : '0'
			}, 1000, function() {
				$(this).css('display', 'none');
			});

			$('#animacja_larrego').css('display', 'block');
			$('#animacja_larrego2').css('display', 'block');
			$('#animacja_larrego2').css('opacity', '1');

			$('#pytanie_larrego p').html(
					'<b>Larry: </b>' + pytania[aktualnieZadanePytanieLarrego]);

			$('#pytanie_larrego span').html(
					'Question ' + aktualnieZadanePytanieLarrego + ' of 4');

			stopSound();
			czytany_tekst = 'sounds/insurance/question-'
					+ aktualnieZadanePytanieLarrego;// +'.ogg';
					
					
			var delayedTime = 1;
			

			
			if (aktualnieZadanePytanieLarrego == 1)
				delayedTime = 1000;
					
			setTimeout(function(){
				playSound(czytany_tekst);	
								
			},delayedTime);
			


			// mimika lemmego
			playMode_2 = 1;
			imageIndex_2 = 1;
			tworzZdjeciaDoAnimacji2_sp03_idle();
			updateAnim_2();
			animationsCircleCounter = 0;
			animationsCircleCounter_2 = 0;

			aktualnieWyswietlanaAnimacja = 'larry_talking';


			if (aktualnieZadanePytanieLarrego == 1
					|| aktualnieZadanePytanieLarrego == 3)
			{	
				
				setTimeout(function(){
					
					tworzZdjeciaDoAnimacji_larry_taking13();
					
					playMode = 1;
					imageIndex = 1;
					updateAnim();					
						},delayedTime)
				
				
				
			}
			else
			{
				tworzZdjeciaDoAnimacji_larry_taking24();
				
				playMode = 1;
				imageIndex = 1;
				updateAnim();				

			}




			ustawCzas_larry_taking(true);

			// time after playing next sound
			var time = new Array();
			time[1] = 3000 + 1000; //delay
			time[2] = 4000;
			time[3] = 3000;
			time[4] = 3000;

			clearTimeout(answersTimeOut);
			answersTimeOut = setTimeout(function() {

				if (aktualnaStrona == 'getting-landlord-insurance')
					next_pytanie_larrego();

			}, time[aktualnieZadanePytanieLarrego] + 500);

		}, delayTime);
	}
}

//displaying response
function next_pytanie_larrego() {

	if (aktualnaStrona == 'getting-landlord-insurance') {
		gli_is_takling = 'lenny';

		if (aktualnieZadanePytanieLarrego == 0)
			aktualnieZadanePytanieLarrego = 1;

		var odpowiedzi = new Array();
		odpowiedzi[1] = 'As well as buildings and contents insurance, specific landlord policies can cover risks such as tenants defaulting on their rent, loss of rent due to property being damaged and becoming uninhabitable, and cover if someone makes a compensation claim for injury or damage. ';
		odpowiedzi[2] = 'It depends on your situation, but buildings and public liability cover are often included as standard. If your property is furnished, you could consider contents insurance. Other covers include accidental damage, alternative accommodation, loss of rent and legal expenses. ';
		odpowiedzi[3] = 'This depends on things like the amount it would cost to rebuild your property and where it’s located. Also, whether it’s residential or commercial, the type of property (e.g. detached house or flat), when it was built, and what materials it is made of. ';
		odpowiedzi[4] = 'It is a good idea to compare quotes from different insurers. You can do this comparison online by visiting the website of an online insurance broker such as Simply Business, to compare quotes from a number of providers by completing a single form. ';

		$('#odpowiedz_lennego').css({
			'display' : 'block',
			'opacity' : '0'
		}).animate({
			'opacity' : '1'
		});

		$('#pytanie_larrego').animate({
			'opacity' : '0'
		}, 1000, function() {
			$(this).css('display', 'none');
		});

		$('#odpowiedz_lennego p').html(
				'<b>Keith (landlord insurance expert from Simply Business): </b>'
						+ odpowiedzi[aktualnieZadanePytanieLarrego]);
		$('#odpowiedz_lennego span').html(
				'Answer ' + aktualnieZadanePytanieLarrego + ' of 4');

		animationsCircleCounter = 0;
		animationsCircleCounter_2 = 0;

		// dźwięk
		stopSound();
		czytany_tekst = 'sounds/insurance/answer-'
				+ aktualnieZadanePytanieLarrego; // +'.ogg';
		playSound(czytany_tekst);

		// mimika lemmego
		playMode_2 = 1;
		imageIndex_2 = 0;
		tworzZdjeciaDoAnimacji2_sb_talking();
		updateAnim_2();

		// larry
		playMode = 1;
		tworzZdjeciaDo1AnimacjiLarryIdle();
		imageIndex = 1;
		updateAnim();

		// time after playing next sound
		var time = new Array();
		time[1] = 15000;
		time[2] = 17500;
		time[3] = 15500;
		time[4] = 0;

		clearTimeout(answersTimeOut);

		if (time[aktualnieZadanePytanieLarrego] != 0) {
			answersTimeOut = setTimeout(function() {

				if (aktualnaStrona == 'getting-landlord-insurance')
					next_odpowiedz_lennego();

			}, time[aktualnieZadanePytanieLarrego] + 2000);
		}

		if (time[aktualnieZadanePytanieLarrego] == 0) {

			nextBtnAnimTimeoutId = setTimeout(function() {

				if (aktualnaStrona == 'getting-landlord-insurance')
					setBlinkingArrow();
			}, 15000 + 1500);
		}

	}
}

function zamknij_dialog_larrego() {

	$('#tekst_dialogu').animate({
		'opacity' : '0'
	}, 1000, function() {
		$(this).css({
			'display' : 'none',
			'opacity' : '1'
		});
	});

}

function pauseVideo() {
	$('iframe[src*="https://www.youtube.com/embed/"]').each(
			function(i) {
				var func = 'pauseVideo';// this === frame ? 'playVideo' :
								
				this.contentWindow.postMessage('{"event":"command","func":"'
						+ 'stopVideo' + '","args":""}', '*');
			});
}

function playVideo(video) {

	pauseVideo();
	$(video + ' iframe').each(
			function(i) {
				var func = 'playVideo';
				this.contentWindow.postMessage('{"event":"command","func":"'
						+ func + '","args":""}', '*');
			});
}

function animImageInc() {
	if (imageIndex < numOfImages)
		imageIndex++
	else {
		// po zakończeniu 1 animacji, wyświetl następną

		if (aktualnaStrona == 'pre-rental-checklist'
				&& aktualnieWyswietlanaAnimacja == 'larry_list'
				|| (aktualnaStrona == 'getting-landlord-insurance' && gli_is_takling == 'larry')) {
			playMode = 2;
		} else

		if (aktualnaStrona == 'signing-tenancy-agreement') {

			if (aktualnieWyswietlanaAnimacja == 'larry_list_chowa') {
				tworzZdjeciaDo1AnimacjiChodzenia();

				aktualnieWyswietlanaAnimacja = 'larry_talking';

				animacjaLarregoIVideo('video2', true, false);

			}
		} else if (aktualnaStrona == 'getting-landlord-insurance') {

			if (aktualnieZadanePytanieLarrego == 0
					&& aktualnieWyswietlanaAnimacja == 'larry_cycle') {
				aktualnieZadanePytanieLarrego = 'larry_talking';
				next_odpowiedz_lennego();

			}
		} else if (aktualnaStrona == 'the-end'
				&& aktualnieWyswietlanaAnimacja == 'larry_walking') {
			imageIndex_2 = 1;
			tworzZdjeciaDoAnimacji2_sp01_idle();
			updateAnim_2();

			playMode = 1;

			tworzZdjeciaDoAnimacji_larry_celebrate();
			imageIndex = 0;
			updateAnim();

			aktualnieWyswietlanaAnimacja = 'larry_celebrate';

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

			$('#finish_page').css({
				'display' : 'block',
				'top' : "500px"
			});

			$('#finish_page').animate({
				top : '50px'
			}, 2000);


			showSocialButtons('end');
		}

		imageIndex = 1;

	}
}// animImageInc

function ustawCzas_larry_taking(odpowiadaNaPytania) {
	if (odpowiadaNaPytania) {
		timeoutValue = 300;
		animDelay = 300;
	} else {
		timeoutValue = 100;
		animDelay = 1000;
	}

}

function setBlinkingArrow() {
	$('#przycisk_nav a').css('background-image',
			"url('layout/button_next.gif')");
}

function setStaticArrow() {
	$('#przycisk_nav a').css('background-image', "url('layout/next_btn.png')");
}
