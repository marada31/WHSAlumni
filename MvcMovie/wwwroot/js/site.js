 

 $(document).ready(function(){
  $(".increaseFont,.decreaseFont").click(function(){
  var type=  $(this).val();
   var curFontSize = $('.data').css('font-size');
  
   if(type=='A▲'){
    $('.data').css('font-size', parseInt(curFontSize)+1);
    }
   else{
    $('.data').css('font-size', parseInt(curFontSize)-1);
   }
     });
 });
