   var CCOUNT = 15;
     
    var t, count;
    function cddisplay() {
        document.getElementById('time').innerHTML = count;
    };
    
    function countdown() {
        cddisplay();
        if (count == 0) {
        	nextPage();
        } else {
            count--;
            t = setTimeout("countdown()", 1000);
        }
    };
    
    function cdpause() {
        clearTimeout(t);
    };
    
    function cdreset() {
        cdpause();
        count = CCOUNT;
        cddisplay();
    };


setTimeout(function(){
	countdown();
},500);

// function timer(){

// 	function setTimer(){
// 		var obj=document.getElementById('time');
// 		obj.innerHTML--;
// 		if(obj.innerHTML==0) {
// 			nextPage();
// 			obj.innerHTML=10; 
// 			setTimeout(setTimer,1000);
// 		}
// 		else{ setTimeout(setTimer,1000); }
// 	}

// 	setTimeout(setTimer,1000);
// }