function initFunctionality(){
	// build article list:
	var i = 0,
		listItem = '',
		datalength = data.length,
		cc = $('#centreContent');
	// The following was originally used to programmatically generate the html but is no longer needed. I am keeping it around just in case changes need to be made:
	/*$.each(data,function(){
		var activeClass = '';
		if(i===0) activeClass  = 'active';
		listItem += '<li class="item '+data[i]['position']+' '+activeClass+'" id="item'+i+'">';
			listItem += '<div class="query"><h5>'+data[i]['question']+'</h5></div>';
			listItem += '<span class="nextArrow '+data[i]['position']+'"></span>';
			listItem += '<div class="noButton"><a href="#">No</a></div>';
		listItem += '</li>';
		i++;
	});*/
	//$('#slides').html(listItem);
	//cc.find('h2').html(data[0]['question']);
	
	// Generate the list in the centre. Calls itself to loop recursively, like a boss.
	function addListLink(i, list, id){
		if(typeof data[id]['link'+i] !== 'undefined' && data[id]['link'+i] !== '') {
			var targetBlank = (data[id]['type'+i] == 'Post' || data[id]['type'+i] == 'Tool') ? ' target="_blank"' : '';
			var targetBlank = (data[id]['type'+i] == 'Checklist' || data[id]['type'+i] == 'Links') ? 'data-id="'+data[id]['link'+i]+'"' : targetBlank; //fix because IE7 is a dick and won't accept just the href
			list += '<li><strong>'+data[id]['type'+i]+'</strong> <a class="cbLink '+data[id]['type'+i]+'" href="'+data[id]['link'+i]+'"'+targetBlank+'>'+data[id]['description'+i]+'</a></li>';
			return addListLink(i+1,list, id);
		} else {
			return list;
		};
	}
	
	cc.find('ul').html(addListLink(1,'',0));
	
	
	// Behaviours:
	
	var overlay = $("#overlay,#modalWindow"), //cache element calls
		mc = $('#modalContent'),
		vc = $('#videoContainer');
		
	$('.noButton').find('a').on('click',function(e){
		e.preventDefault();
		$('.item').removeClass('active');
		$(this).parents('.item').addClass('active');
		var itemID = $(this).parents('.item').attr('id').substr(4,2);
		cc.find('h2').html(data[itemID]['question']);
		cc.find('ul').html(addListLink(1,'',itemID));
		if(vc.is(':visible')) {vc.fadeOut(400,function(){$(this).find('#video').empty();});}
		
		$('.np').removeClass('inactive');
		if(itemID > datalength-2) {
			$('#next').addClass('inactive');
		}
		if(itemID < 1) {
			$('#prev').addClass('inactive');
		}
	});
		
	$('#next').on('click',function(e){
		e.preventDefault();
		var itemID = $('.active').attr('id').substr(4,2);
		if(itemID < datalength-1) {
			$('.item').removeClass('active');
			itemID++;
			$('#item'+itemID).addClass('active');
			cc.find('h2').html(data[itemID]['question']);
			cc.find('ul').html(addListLink(1,'',itemID));
		}
		if(itemID < datalength-2) {
			$('.np').removeClass('inactive');
		}else {
			$('#next').addClass('inactive');
		}
		if(vc.is(':visible')) {vc.fadeOut(400,function(){$(this).find('#video').empty();});}
	});
	
	$('#prev').on('click',function(e){
		e.preventDefault();
		var itemID = $('.active').attr('id').substr(4,2);
		if(itemID > 0) {
			$('.item').removeClass('active');
			itemID--;
			$('#item'+itemID).addClass('active');
			cc.find('h2').html(data[itemID]['question']);
			cc.find('ul').html(addListLink(1,'',itemID));
		}
		if(itemID > 1) {
			$('.np').removeClass('inactive');
		}else {
			$('#prev').addClass('inactive');
		}
		if(vc.is(':visible')) {vc.fadeOut(400,function(){$(this).find('#video').empty();});}
	});
	
	$('#centreContent').on('click','.cbLink',function(e){
		if($(this).hasClass('Checklist') || $(this).hasClass('Links')){
			e.preventDefault();
			var thisID = $(this).attr('data-id');
			console.log(thisID);
			mc.html(checklists[thisID]);
			overlay.fadeIn(400);
		} else if($(this).hasClass('Video')){
			e.preventDefault();
			vc.fadeIn(400).find('#video').html($(this).attr('href'));
		};
	});
	
	$('#closeVideo').on('click',function(e){
		e.preventDefault();
		vc.fadeOut(400,function(){$(this).find('#video').empty();});;
	});
	
	
	$('.closeOverlay').on('click',function(e){
		e.preventDefault();
		if (overlay.is(":visible")) {
			overlay.fadeOut(800,function(){
				mc.empty();
			});
		} else {
			overlay.fadeIn(400);
		}
		return false;
	});
	
	$(".embedLink").on('click',function(){
		if ($("#embed").hasClass("visible")) {
			$("#embed").animate({bottom:'-200px'},'slow').removeClass("visible");
		} else {
			$("#embed").animate({bottom:'0px'},'slow').addClass("visible");
		}
		return false;
	});
}