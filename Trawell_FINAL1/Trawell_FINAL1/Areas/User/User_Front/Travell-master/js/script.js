//Tooltips
$('[data-toggle="tooltip"]').tooltip()
//Tooltips END
var monthNames = ["January", "February", "March", "April", "May", "June",
  "July", "August", "September", "October", "November", "December"
];
var weekdays = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
// Comming Soon Timer

$( document ).ready(function() {
	
    function timer(){
        var FullDate = new Date()
        var FinalDate = new Date("2018-02-01 00:00:00")
        var DifDate = new Date(FinalDate - FullDate)
        
        var NowDay = Math.round( DifDate/1000/60/60/24 );
        var NowMinute = DifDate.getMinutes()
        var NowHour = DifDate.getHours()
        var NowSecond = DifDate.getSeconds()
        $("#CommingSoon .container-fluid .row .col-md-12 .content .timer .days strong").text(function day() {
        if(NowDay.toString().length == 1){
            NowDay = '0' + NowDay
        }
        return NowDay
    })
    $("#CommingSoon .container-fluid .row .col-md-12 .content .timer .hour strong").text(function hour() {
        if(NowHour.toString().length == 1){
            NowHour = '0' + NowHour
        }
        return NowHour
    })
    $("#CommingSoon .container-fluid .row .col-md-12 .content .timer .minute strong").text(function minute() {
        if(NowMinute.toString().length == 1){
            NowMinute = '0' + NowMinute
        }
        return NowMinute
    })
    $("#CommingSoon .container-fluid .row .col-md-12 .content .timer .second strong").text(function second() {
        if(NowSecond.toString().length == 1){
            NowSecond = '0' + NowSecond
        }
        return NowSecond
    })
    }
    
    var SS =  setInterval(function(){ timer() }, 1000)

	

});


// Comming Soon Timer END

//Flags Drop

$(document).ready(function(){
    var count = 1
        $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .flaglink a").click(function(){
       if(count==1){
             $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .flags").show(100).animate({
            top: "36px",
        })
     $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .Triangle").show(100)              
        // $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .flaglink a i").animate({
        //     transform: 'rotate(' + 90 + 'deg)',
        //      transform: 'translateX(50px)'
        // })   
             count++
       }else{
            $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .flags").hide(50)
            $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .Triangle").hide(50)
            $("#header .headerTop .container .row .search .container-fluid .row .col-md-4 .FlagDrop .flags").css("top", "40px")

            count--
       }
    });
});
//Flags Drop END
//DropDown

$(document).ready(function(){
{
     $("header .NavBar .container .row .col-lg-12 .collapse .navbar-nav .nav-item").hover(function(){
        if($(window).width()>=992){
            $(this).children('ul').addClass("Drop")
            $("header .NavBar .container .row .col-lg-12 .collapse .navbar-nav .nav-item .Drop").slideDown("fast")
        }
        
             
        
       
    });
      $("header .NavBar .container .row .col-lg-12 .collapse .navbar-nav .nav-item").mouseleave(function(){
          if($(window).width()>=992){
            $("header .NavBar .container .row .col-lg-12 .collapse .navbar-nav .nav-item .Drop").slideUp("fast")
            $(this).children('ul').removeClass('Drop')
         }
        

    });
}
   
});








//PopUp
    var CurrentImg
    var CurrentCount
    var CountOfImg = $(".container .row .Gallary .tab-content .Photos .container-fluid .row .col-lg-3").length
    $(".container .row .Gallary .tab-content .Photos .container-fluid .row .col-lg-3 i").click(function(){
        CurrentImg = $(this).prev().attr('src')
        CurrentCount =parseInt($(this).prev().attr('count')) 
        
        $("#PopUp .container-fluid .row .col-lg-12 p .FirstSide").text(CurrentCount+1)
       
         $("#PopUp .container-fluid .row .col-lg-12 img").attr('src',CurrentImg)
        $("#PopUp").fadeIn(100,'swing', function() {
              $("#PopUp .container-fluid .row .col-lg-12").css({'opacity' : '1','transform' : 'scale(1,1)'})
        });
      
       
       
    });
    //RightClick
    $("#PopUp .container-fluid .RightClick").click(function () {
        CurrentCount++
       if(CurrentCount == CountOfImg){
        CurrentCount=0
       }
       $("#PopUp .container-fluid .row .col-lg-12 p .FirstSide").text(CurrentCount+1)
       CurrentImg =  $(".container .row .Gallary .tab-content .Photos .container-fluid .row .col-lg-3 img[count='"+CurrentCount+"']").attr('src')
       
       $("#PopUp .container-fluid .row .col-lg-12 img").attr('src',CurrentImg)
    });
    //LeftClick
    $("#PopUp .container-fluid .LeftClick").click(function () {
       CurrentCount--
       if(CurrentCount == -1){
        CurrentCount=CountOfImg-1
       }
       $("#PopUp .container-fluid .row .col-lg-12 p .FirstSide").text(CurrentCount+1)
       CurrentImg =  $(".container .row .Gallary .tab-content .Photos .container-fluid .row .col-lg-3 img[count='"+CurrentCount+"']").attr('src')
       
       $("#PopUp .container-fluid .row .col-lg-12 img").attr('src',CurrentImg)
    });
    //Close Click
    $("#PopUp .container-fluid .CloseClick").click(function () {
        $("#PopUp").fadeOut(300,'swing'); 
       $("#PopUp .container-fluid .row .col-lg-12").css({'opacity' : '0' ,'transform' : 'scale(2,2)'}) 
        

    });
  
  

//PopUpEND



$("#inlineFormInputGroup").click(function(){
    $(".input-group-addon").addClass("color-org");

});




$(".icon1").click(function(){
$(".lightBox").css({"transform": "scale(3,3)", "transform": "rotateY(20deg)"});





$(this).css("display","none")

});
jQuery(document).ready(function() {
    //DataPicker
$('.datepicker').datepicker({
    format: "MM dd , yyyy",
    todayHighlight: true,
    toggleActive: true,

})

//Data Picker END
});
//TimePicker

$('.CheckInTime .CheckTime').click(function (e) {
     e.preventDefault()
        var InputVal = $(this).val()
        $(this).parent().next().children().eq(1).children('p').text(InputVal.substring(0, 2))
        $(this).parent().next().children().eq(1).children('p').text(InputVal.substring(3, 5))
        $(this).parent().next().children().eq(1).children('p').text(InputVal.substring(6, 8))
        if($(this).parent().next().css('display') == 'none'){
            $('.CheckInTime .InTime').fadeOut(300)
        }
        
        $(this).parent().next().fadeIn(300);

  
});
$(document).mouseup(function(e) 
{
    var container = $('.CheckInTime .InTime');
    var container2 = $('.CheckInTime .CheckTime');
    // if the target of the click isn't the container nor a descendant of the container
    if (!container.is(e.target) && container.has(e.target).length === 0 & !container2.is(e.target) && container2.has(e.target).length === 0) 
    {
        container.fadeOut(300);
    }
});
$('.CheckInTime .InTime .HT').click(function (e) {
    e.preventDefault();
    var Hour = $(this).next().text()
    Hour++
    if(Hour == 13){
        Hour = 1
    }
    $(this).next().text(Hour)

    var Total = $(this).next().text()+':'+$(this).parent().next().children('p').text()+' '+$(this).parent().next().next().children('p').text()

    $(this).parent().parent().parent().prev().children('input').val(Total)
});
$('.CheckInTime .InTime .HB').click(function (e) {
    e.preventDefault();
    var Hour = $(this).prev().text()
    Hour--
    if(Hour == 0){
        Hour = 12
    }
    $(this).prev().text(Hour)
    var Total = $(this).prev().text()+':'+$(this).parent().next().children('p').text()+' '+$(this).parent().next().next().children('p').text()
    $(this).parent().parent().parent().prev().children('input').val(Total)
});
$('.CheckInTime .InTime .MT').click(function (e) {
    e.preventDefault();
    var Minute = $(this).next().text()
    if(Minute == '00'){
        Minute = 0
    }
    Minute = parseInt(Minute)
    Minute=Minute+15
    if(Minute == 60){
        Minute = 0
    }
    if(Minute == 0){
        Minute = Minute + '0'
    }
    $(this).next().text(Minute)

    var Total = $(this).parent().prev().children('p').text()+':'+$(this).next().text()+' '+$(this).parent().next().children('p').text()
    $(this).parent().parent().parent().prev().children('input').val(Total)
});
$('.CheckInTime .InTime .MB').click(function (e) {
    e.preventDefault();
    var Minute = $(this).prev().text()
    if(Minute == '00'){
        Minute = 0
    }
    Minute = parseInt(Minute)
    Minute=Minute-15
    if(Minute < 0){
        Minute = 45
    }
    if(Minute == 0){
        Minute = Minute + '0'
    }
    $(this).prev().text(Minute)
    var Total = $(this).parent().prev().children('p').text()+':'+$(this).prev().text()+' '+$(this).parent().next().children('p').text()
    $(this).parent().parent().parent().prev().children('input').val(Total)
});
$('.CheckInTime .InTime .APT').click(function (e) {
    e.preventDefault();
    var AP = $(this).next().text()
    if(AP == 'AM'){
        AP = 'PM'
    }
    else{
        AP = 'AM'
    }
    $(this).next().text(AP)
    var Total = $(this).parent().prev().prev().children('p').text()+':'+$(this).parent().prev().children('p').text()+' '+$(this).next().text()
    $(this).parent().parent().parent().prev().children('input').val(Total)
});
$('.CheckInTime .InTime .APB').click(function (e) {
    e.preventDefault();
    var AP = $(this).prev().text()
    if(AP == 'AM'){
        AP = 'PM'
    }
    else{
        AP = 'AM'
    }
    $(this).prev().text(AP)
    var Total = $(this).parent().prev().prev().children('p').text()+':'+$(this).parent().prev().children('p').text()+' '+$(this).prev().text()
    $(this).parent().parent().parent().prev().children('input').val(Total)
});

//TimePickerEnd

//ChooseRange PlaceHolder
jQuery(document).ready(function($) {
    var fullDate = new Date();
    var newdate = new Date(fullDate);
    newdate.setDate(newdate.getDate() + 7);
    var nd = new Date(newdate);
    
   
    $("input.CheckIn").attr('value',monthNames[fullDate.getUTCMonth()] +' ' + fullDate.getDate() + ', '+ weekdays[fullDate.getUTCDay()-1])
    $("input.CheckIn").attr('placeholder',monthNames[fullDate.getUTCMonth()] +' ' + fullDate.getDate() + ', '+ weekdays[fullDate.getUTCDay()-1])
    $("input.CheckOut").attr('value',monthNames[nd.getUTCMonth()] +' ' + nd.getDate() + ', '+weekdays[nd.getUTCDay()-1])
    $("input.CheckOut").attr('placeholder',monthNames[nd.getUTCMonth()] +' ' + nd.getDate() + ', '+weekdays[nd.getUTCDay()-1])
});


////ChooseRange PlaceHolder END
//Adults Children 4+
$(".Adults .form-group .AdultsBtnGroup .Adults5").click(function () {
    $(".Adults .form-group .AdultsBtnGroup").addClass("hidden-sm-up hidden-sm-down")
    $(".Adults .form-group .AdultsSectionGroup").removeClass("hidden-sm-up hidden-sm-down")
    
});
//Adults Children 4+ END
//Children Children 4+
$(".Children .form-group .ChildrenBtnGroup .Children5").click(function () {
    $(".Children .form-group .ChildrenBtnGroup").addClass("hidden-sm-up hidden-sm-down")
    $(".Children .form-group .ChildrenSectionGroup").removeClass("hidden-sm-up hidden-sm-down")
  
});
//Adults Children 4+ END
//Guests Children 4+
$(".Guests .form-group .GuestsBtnGroup .Guests5").click(function () {
    $(".Guests .form-group .GuestsBtnGroup").addClass("hidden-sm-up hidden-sm-down")
    $(".Guests .form-group .GuestsSectionGroup").removeClass("hidden-sm-up hidden-sm-down")
    
});
//Guests Children 4+ END
//Guests Children 4+
$(".Rooms .form-group .RoomsBtnGroup .Rooms5").click(function () {
    $(".Rooms .form-group .RoomsBtnGroup").addClass("hidden-sm-up hidden-sm-down")
    $(".Rooms .form-group .RoomsSectionGroup").removeClass("hidden-sm-up hidden-sm-down")
    
});
//Guests Children 4+ END

//CheckBox
$('.CarDetailLeft .CheckBox .i-checker ins').click(function () {

    if($(this).parent().hasClass('checked color-second')){
          $(this).parent().removeClass('checked color-second')
           $(this).parent().css('border', '1px solid #ccc');
        $(this).prev().css({
            'top': '-45px',
            'z-index':'-1'
        });
         
          
    }else{
         $(this).parent().addClass('checked color-second')
         $(this).parent().css('border', '1px solid #0ebcf2');
        $(this).prev().css({
            'top': '-21px',
            'z-index': '1'
        });
       
    }
});

$('.FilterInto .Checkbox .i-checker ins').click(function () {
   
    if($(this).parent().hasClass('checked color-second')){
          $(this).parent().removeClass('checked color-second')
          $(this).parent().css('border', '1px solid #ccc');
        $(this).prev().css({
            'top': '-25px',
            'z-index':'-1'
        });
         
          
    }else{
         $(this).parent().addClass('checked color-second')
         $(this).parent().css('border', '1px solid #0ebcf2');
        $(this).prev().css({
            'top': '2px',
            'z-index': '1'
        });
       
    }
});


//CheckBox

//SortRanking
var SortCount = 0
 $(".SortRanking span").click(function () {
   
    if(SortCount == 0){
        
         $(".SortRanking .SortTriangle").show(100)
      $(".SortRanking .SortingBy").show(100).animate({
         'top': '30px'
     });
      SortCount++
    }
    else{
          $(".SortRanking .SortTriangle").hide()
      $(".SortRanking .SortingBy").hide().animate({
         'top': '34px'
     });
      SortCount--
    }
    
 });
//SortRanking END

//TrySearch
//Activities
$(".TrySearchActivities").click(function (e) {
    e.preventDefault();
    $('#ChangeSearchaActivities').fadeIn(500)
});
$('#ChangeSearchaActivities .CloseClick').click(function () {
    $('#ChangeSearchaActivities').fadeOut(500)
});
//Cars
$(".TrySearchCars").click(function (e) {
    e.preventDefault();
    $('#ChangeSearchCars').fadeIn(500)
});
$('#ChangeSearchCars .CloseClick').click(function () {
    $('#ChangeSearchCars').fadeOut(500)
});
//Rentals
$(".TrySearchRental").click(function (e) {
    e.preventDefault();
    $('#ChangeSearchRental').fadeIn(500)
});
$('#ChangeSearchRental .CloseClick').click(function () {
    $('#ChangeSearchRental').fadeOut(500)
});
//Flights
$(".TrySearchFlights").click(function (e) {
    e.preventDefault();
    $('#ChangeSearcFlights').fadeIn(500)
});
$('#ChangeSearcFlights .CloseClick').click(function () {
    $('#ChangeSearcFlights').fadeOut(500)
});
//TrySearch
//Range
  $(function () {

        $("#RentalRange").ionRangeSlider({
            
            
            min: 130,
            max: 575,
            from: 130,
            to: 575,
            type: 'double',
            step: 1,
            prefix: "$",
            grid: true
        });

    });
//Range END
//Get Location
function initialize() {

    var acInputs = document.getElementsByClassName("autocomplete");

    for (var i = 0; i < acInputs.length; i++) {

        var autocomplete = new google.maps.places.Autocomplete(acInputs[i]);
        autocomplete.inputId = acInputs[i].id;

        google.maps.event.addListener(autocomplete, 'place_changed');
    }
}
initialize()

$("body").click(function(){
    $('body').hide()
});
//Get Location End