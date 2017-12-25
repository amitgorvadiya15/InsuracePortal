(function(){
    function showAnswer($this){
        $this.parent()
             .addClass('expanded')
             .find('.answer').slideDown(400, function(){
                $this.parent().find('.hide').slideDown('fast');
             });
    }
    function hideAnswer($this){
        $this.parent()
             .find('.hide, .answer').slideUp(400 , function (){
                $this.parent().removeClass('expanded');
             });
    }

    $('.no').on('click', function(e){
        e.preventDefault();
        var $this = $(this).parent();
        showAnswer($this);
    });
    $('.hide').on('click', function(e){
        e.preventDefault();
        var $this = $(this).parent();
        hideAnswer($this);
    });

    $('.embedLink,.close-embed').click(function(e){
        e.preventDefault();
        showHideEmbed();
    });

    function showHideEmbed(){
        var $embed = $("#embed");
        if ($embed.hasClass("visible")) {
            $embed.animate({bottom:'-200px'},'slow').fadeOut({queue:false}).removeClass("visible");
        } else {
            $embed.animate({bottom:'0px'},'slow').fadeIn({queue:false}).addClass("visible");
        }
    };
    function fixSocialScroll(){
        $('#social-scroll').addClass('fixed').css('top','0px');
    }
    function releaseSocialScroll(bottom){
        $('#social-scroll').addClass('held').removeClass('fixed').css('top', bottom);
    }
    $(window).on('scroll', function(){
            if ($('html').hasClass('ie8') || $('html').hasClass('ie9')) {} else {
            var top = $(document).scrollTop();
            var height = $('#social-scroll').outerHeight(true);
            var footer = $('footer').offset().top;
            var foot = $('footer').outerHeight(true);
            var view = $(window).height();
            var doc = $(document).outerHeight(true)

            if (top > 160 && !$('#social-scroll').hasClass('held')) {
                fixSocialScroll();
            }
            if ((top + height) > footer) {
                var bottom = footer - height;
                releaseSocialScroll(bottom);
            }
            if(top < (doc-foot-height+40) && $('#social-scroll').hasClass('held')) {
                fixSocialScroll();
            }
            if (top < 160) {
                $('#social-scroll').removeClass('fixed').css('top', '160px');
            }
        }
    });
})();
