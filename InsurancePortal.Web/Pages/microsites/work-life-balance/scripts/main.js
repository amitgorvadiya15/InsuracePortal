"use strict";
// *************************************************************
// Parallax effect
// *************************************************************
if(typeof Muse == "undefined") window.Muse = {}; window.Muse.assets = {"required":["jquery-1.8.3.min.js", "museutils.html", "jquery.scrolleffects.html", "jquery.watch.js"], "outOfDate":[]};
document.documentElement.className = 'js';

$(document).ready(function($) {
	var module = {},
		quiz  =  {
			'rules' : {
				a: {defeats: ["b", "d"]},
			    b: {defeats: []},
			    c: {defeats: ["a", "b", "d"]},
			    d: {defeats:["b"]}
			},
			'answers' :  []
			
		}
	
		module = {
			'model' : {
				// *************************************************************
				// this sorts the answers and returns them (most popular first)
				// *************************************************************
				mutateQuizAnswers: function (answers) {
					var arr = [];
				    for (var prop in answers) {
				        if (answers.hasOwnProperty(prop)) {
				            arr.push({
				                'question': prop,
				                'value': answers[prop]
				            });
				        }
				    }
				    arr.sort(function(a, b) { return b.value - a.value; });
				    return arr; 
				}
			}, 
			'controller' : {
				// *************************************************************
				// add the selected answer to the list
				// *************************************************************
				addQuizAnswer: function(answer) {
					quiz.answers.push(answer);
				},
				// *************************************************************
				// collates all the answers for the 4 individual questions 
				// and returns them in an object
				// *************************************************************
				collateQuizAnswers: function(answers) {
					var collatedAnswers = {};
			   	 	for(var i = 0; i < answers.length; ++i) {
			   	 	    if(!collatedAnswers[answers[i]])
			   	 	        collatedAnswers[answers[i]] = 0;
			   	 	    ++collatedAnswers[answers[i]];
			   	 	}
					return collatedAnswers;
				},
				// *************************************************************
				// this checks if we have a tie between answers and 
				// returns the number of ties if the case
				// *************************************************************
				 checkForTie: function(arrayToSearch, searchTerm, property) {
					var lastIndex = -1;

				    for(var i = 0, len = arrayToSearch.length; i < len; i++) {

				        if (arrayToSearch[i]['value'] == searchTerm) {
							lastIndex = i;
						};
				    }
				    return lastIndex;
				},
				// *************************************************************
				// decides which answers wins in case of a tie
				// *************************************************************	
				decideQuizWinner: function(results) {
					var arrayLength = results.length,
						victory = '',
						keep;

					while (results.length > 1) {
						victory = quiz.rules[results[0]['question']].defeats.indexOf(results[1]['question']) > -1;
						keep = victory ? results[0]: results[1];


						results.push(keep);
					    results = results.slice(2, results.length);
					}
					
					return results[0]['question'];
				},
				// *************************************************************
				// runs all the checks when the quiz has been finished 
				// to determine the winner
				// *************************************************************
				getQuizResult: function() {
					var results 				= module.controller.collateQuizAnswers(quiz.answers),
						resultsByPopularity 	= module.model.mutateQuizAnswers(results),
						indexOfMostPopularItem 	= Math.max.apply(null, resultsByPopularity.map(function(obj) { return obj.value;}));
						
						
						indexOfMostPopularItem = module.controller.checkForTie(resultsByPopularity, indexOfMostPopularItem, "value");
						resultsByPopularity = resultsByPopularity.slice(0, indexOfMostPopularItem+1);
					
						return module.controller.decideQuizWinner(resultsByPopularity);
				},
				// *************************************************************
				// start the quiz 
				// *************************************************************
				initiateQuiz: function() {
					quiz.answers = [];
					$(".quiz-slideshow").cycle(1);
				}
			},
			'view' : {
				// *************************************************************
				// bind event handlers
				// *************************************************************
				bindEvents : function() {
					//anchors
					$("a[href^='#']").on('click', function(e) {
						var hash = this.hash,
							scrollTo;
							e.preventDefault();
							
							
						if ($(hash).length > 0) {
							scrollTo = $(hash).offset().top;
							
							if (navigator.userAgent.match(/(iPod|iPhone|iPad|Android)/)) {
								//scrollTo = document.getElementById(hash.split("#").join("")).offsetTop;
								window.scrollTo(0,scrollTo);
								window.location.hash = hash;
							} else {
								$('html, body').animate({
									scrollTop: scrollTo
								}, 300, function(){
									window.location.hash = hash;
								});
							}
						}
					});

					//start quiz
					$("#quiz a.lets-go").on('click', function(e) {
						module.controller.initiateQuiz();
						e.preventDefault();
					});

					//individual quiz questions
					$("#quiz label").on('click', function(e) {
						var nextSlide = $('.quiz-slideshow').data('cycle.opts').nextSlide;
						
						module.controller.addQuizAnswer($(this).find('input:radio').val());

						if (nextSlide === 0 ) {	
							var quizResult = module.controller.getQuizResult().toLowerCase(),
								quizResultSlide = '<div data-question="' + quizResult + '" style="width:100%">' + $('.quiz-results').find('div.' + quizResult).html() + '</div>';
							
							$('.quiz-slideshow').cycle('add', quizResultSlide);
						} 
						//
						$('.quiz-slideshow').cycle('next');	
						//
						e.preventDefault();
					});
				},
				initiateCarousel : function() {
					$('.quiz-slideshow').cycle({
						fx:      'scrollHorz', 
						timeout:  0, 
						captionTemplate: '{{slideNum}} of {{slideCount}}',
						slides:   '> div',
						autoHeight: 'calc',
						centerHorz: true
					});
					
					$('.quiz-slideshow').on( 'cycle-after', function( event, opts ) {
						//scroll back to the top of the next question
						$('#page #u1233').css({'paddingBottom': ($('div#quiz').height() + 31) + 'px'});
							var scrollTo;
							
							if (navigator.userAgent.match(/(iPod|iPhone|iPad|Android)/)) {
								scrollTo = document.getElementById('quiz').offsetTop;
								window.scrollTo(0,scrollTo);
							}
								
						
					});
				}
			},
			// *************************************************************
			// run these functions when the site is loaded
			// *************************************************************
			init: function() {
				module.view.bindEvents();
				module.view.initiateCarousel();
				$('input, textarea').placeholder();
			}
		}
		module.init();
	
	
		// *************************************************************
		// Signup forms
		// *************************************************************
		$('#keep-me-posted form, #fancy-a-break form').submit(function (e) {
			var $form = $(this);
			var message = $form.data('message');

			e.preventDefault();

			$.ajax({
				method: 'post',
		  	url: $form.attr('action'),
				data: $form.serialize(),
				dataType: 'json'
			}).done(function (response) {
				$form.replaceWith('<p style="font-size:20px">' + message + '</p>');
			}).fail(function () {
				alert("Oops something went wrong. Please try again later.");
			});
		});

		var sharing = {
			facebook: {
				url: "https://www.facebook.com/dialog/feed",
				defaults: {
					app_id: "724812420978870",
					display: "popup",
					link: "http://www.companyname.co.uk/microsites/work-life-balance/",
					caption: "The company name work-life balance quiz",
					redirect_uri: "http://www.companyname.co.uk/microsites/work-life-balance/done.html"
				},
				a: {
					name: "The Detail Obsessive",
					description: "The quest for perfection gets me out of bed and my desk is immaculate! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath.",
					picture: "http://www.companyname.co.uk/microsites/work-life-balance/images/work_life_balance_og_detail.jpg"
				},
				b: {
					name: "The Taskmaster",
					description: "Some might call me domineering but in fact i'm a visionary decision maker! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath.",
					picture: "http://www.companyname.co.uk/microsites/work-life-balance/images/work_life_balance_og_task.jpg"
				},
				c: {
					name: "The Yogi",
					description: "I like to take my time and give out a free hug or two! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath.",
					picture: "http://www.companyname.co.uk/microsites/work-life-balance/images/work_life_balance_og_yogi.jpg"
				},
				d: {
					name: "The Creative Whirlwind",
					description: "Ideas and inspiration seep from my every pore! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath.",
					picture: "http://www.companyname.co.uk/microsites/work-life-balance/images/work_life_balance_og_creative.jpg"
				}
			},
			twitter: {
				url: "https://twitter.com/share",
				defaults: {
					url: "http://www.companyname.co.uk/microsites/work-life-balance/"
				},
				a: {
					text: 'I got the "The Detail Obsessive" personality! Take the @simplybusiness work-life balance quiz and win prizes #WLB'
				},
				b: {
					text: 'I got the "The Taskmaster" personality! Take the @simplybusiness work-life balance quiz and win prizes here #WLB'
				},
				c: {
					text: 'I got the "The Yogi" personality! Take the @simplybusiness work-life balance quiz and win prizes here #WLB'
				},
				d: {
					text: 'I got the "The Creative Whirlwind" personality! Take the @simplybusiness work-life balance quiz and win prizes #WLB'
				}
			},
			linkedin: {
				url: "https://www.linkedin.com/shareArticle",
				defaults: {
					mini: "true",
					url: "http://www.companyname.co.uk/microsites/work-life-balance/",
					source: "company name",
					title: "The company name work-life balance quiz"
				},
				a: {
					summary: "The quest for perfection gets me out of bed and my desk is immaculate! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath."
				},
				b: {
					summary: "Some might call me domineering but in fact i'm a visionary decision maker! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath."
				},
				c: {
					summary: "I like to take my time and give out a free hug or two! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath."
				},
				d: {
					summary: "Ideas and inspiration seep from my every pore! Take the quiz and win a trip for two to the ancient Thermae Spa in Bath."
				}
			}
		};

		$("#quiz").on("click", ".sharing a", function (e) {
			e.preventDefault();
			var left = (window.screenX + (window.outerWidth - 500) / 2);
			var top = (window.screenY + (window.outerHeight - 300) / 2);

			var key = $(this).data("share");
			var params = $.extend({}, sharing[key].defaults, sharing[key][$(this).data("result")]);
			var url = sharing[key].url + "?";
			$.each(params, function (name, value) {
				url += "&" + name + "=" + encodeURIComponent(value);
			});

			window.open(url, "share", "menubar=no,location=no,resizable=no,scrollbars=no,status=no,width=550,height=350,left=" + left + ",top=" + top);
		});

		$(window).load(function() {
			$( window ).resize(function() {
				$( "#page" ).css({'minHeight': $("#content").height()+'px'});
			})
			
			$( window ).trigger('resize');
		});
		
});