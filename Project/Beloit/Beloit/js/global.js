//return to top
$(window).scroll(function(){
    var top = $(window).scrollTop();
    if(top > 100){
        $("#return-box").show(500);
    }
    else{
        $("#return-box").hide(500);
    }
});

$("#return-box").click(function () {
    $("html").animate({
        scrollTop: 0
    }, 500)
});