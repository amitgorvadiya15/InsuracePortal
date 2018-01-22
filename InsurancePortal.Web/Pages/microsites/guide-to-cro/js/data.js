var artlist = [
{"Question":"Are you familiar with conversion rate optimisation?","Answer1":"A brief introduction to CRO","Answer2":"Reasons to get obsessed with CRO","Link1":"http://www.companyname.co.uk/knowledge/articles/2013/06/introduction-to-cro/","Link2":"http://www.conversion-rate-experts.com/reasons-to-get-obsessed-with-cro/"},
{"Question":"Have you set up your conversion funnel in Google Analytics?","Answer1":"Critical goal types","Answer2":"Conversion funnel survival guide","Link1":"http://blog.kissmetrics.com/critical-goal-types/","Link2":"http://blog.kissmetrics.com/conversion-funnel-survival-guide/"},
{"Question":"Do you know how to identify user issues with your site?","Answer1":"Best ways to get feedback","Answer2":"Priceless CRO advice","Link1":"http://blog.kissmetrics.com/best-ways-to-get-feedback/","Link2":"http://www.seomoz.org/blog/priceless-cro-advice-for-224"},
{"Question":"Do you know what your competitors are doing?","Answer1":"Spying on your competitors","Answer2":"Check your competitors’ messages","Link1":"http://conversionxl.com/spying-on-your-competitors-to-increase-conversion-rates/","Link2":"http://fourleafpr.com/2011/02/analyze-your-competitors-messages-before-developing-your-own-2/"},
{"Question":"Do you know how to run a usability test?","Answer1":"Guerrilla usability testing","Answer2":"","Link1":"http://www.slideshare.net/jtcchan/how-to-run-your-own-guerrilla-usability-testing","Link2":""},
{"Question":"Do you know how to run an effective customer survey?","Answer1":"Improve conversions with surveying","Answer2":"","Link1":"http://blog.kissmetrics.com/improve-conversions-through-surveying/","Link2":""},
{"Question":"Do you know how to run an A/B test?","Answer1":"An introduction to A/B testing","Answer2":"","Link1":"http://usabilitygeek.com/introduction-a-b-testing/","Link2":""},
{"Question":"Do you know which tool to use for A/B testing?","Answer1":"Getting started with Optimizely","Answer2":"","Link1":"https://www.optimizely.com/gettingstarted","Link2":""},
{"Question":"Do you know whether your tests are statistically significant?","Answer1":"Determine statistical significance","Answer2":"A/B testing calculator","Link1":"http://blog.hubspot.com/blog/tabid/6307/bid/25671/How-to-Determine-if-Your-A-B-Test-Results-Are-Significant.aspx","Link2":"http://super.hubspot.com/calculator/"},
{"Question":"Do you know the common mistakes to avoid?","Answer1":"10 do's and don'ts of A/B testing","Answer2":"7 A/B testing blunders","Link1":"http://blog.hubspot.com/blog/tabid/6307/bid/28942/10-Dos-and-Don-ts-of-A-B-Testing.aspx","Link2":"http://www.quicksprout.com/2013/05/02/7-ab-testing-blunders-that-even-experts-make/"},
{"Question":"Do you know what to do when your test fails?","Answer1":"What to do when your split      test fails","Answer2":"","Link1":"http://searchenginewatch.com/article/2183185/What-to-do-When-Your-Split-Test-Fails","Link2":""}
];

function generateLists(){
	// build article list:
	aList = $('#linkList');
	aList.empty();
	var i = 0;
	var aListItem = '';
	$.each(artlist,function(){
		var linkCount = (artlist[i].Link2 === '') ? 'single' : 'double';
		aListItem += '<li class="item"><h6><span>'+artlist[i].Question+'</span></h6><ul class="'+linkCount+'">';
		if (artlist[i].Link1 != ''){
			aListItem += '<li><a href="'+artlist[i].Link1+'" target="_blank">'+artlist[i].Answer1+'</a></li>';
		}
		if (artlist[i].Link2 != ''){
			aListItem += '<li><a href="'+artlist[i].Link2+'" target="_blank">'+artlist[i].Answer2+'</a></li>';
		}
		aListItem += '</ul></li>';
		i++;
	});
	aList.append(aListItem);
}