/*!
 * Start Bootstrap - Freelancer Bootstrap Theme (http://startbootstrap.com)
 * Code licensed under the Apache License v2.0.
 * For details, see http://www.apache.org/licenses/LICENSE-2.0.
 */

// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {
    $('body').on('click', '.page-scroll a', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

// Floating label headings for the contact form
$(function() {
    $("body").on("input propertychange", ".floating-label-form-group", function(e) {
        $(this).toggleClass("floating-label-form-group-with-value", !!$(e.target).val());
    }).on("focus", ".floating-label-form-group", function() {
        $(this).addClass("floating-label-form-group-with-focus");
    }).on("blur", ".floating-label-form-group", function() {
        $(this).removeClass("floating-label-form-group-with-focus");
    });
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function() {
    $('.navbar-toggle:visible').click();
});



/* Thanks to CSS Tricks for pointing out this bit of jQuery
http://css-tricks.com/equal-height-blocks-in-rows/
It's been modified into a function called at page load and then each time the page is resized. One large modification was to remove the set height before each new calculation. */

// equalheight = function(container) {

//     var currentTallest = 0,
//         currentRowStart = 0,
//         rowDivs = new Array(),
//         $el,
//         topPosition = 0;
//     $(container).each(function() {

//         $el = $(this);
//         $($el).height('auto')
//         topPostion = $el.position().top;

//         if (currentRowStart != topPostion) {
//             for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
//                 rowDivs[currentDiv].height(currentTallest);
//             }
//             rowDivs.length = 0; // empty the array
//             currentRowStart = topPostion;
//             currentTallest = $el.height();
//             rowDivs.push($el);
//         } else {
//             rowDivs.push($el);
//             currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
//         }
//         for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
//             rowDivs[currentDiv].height(currentTallest);
//         }
//     });
// }

// $(window).load(function() {
//     equalheight('.row-same-h .column-same-h');
// });


// $(window).resize(function() {
//     equalheight('.main article');
// });