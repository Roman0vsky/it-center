var inp = document.getElementById("tel");
var old = 0;

inp.addEventListener('click', e => {
    inp.value = "+375";
});

inp.addEventListener('keydown',  function() {
    var curLen = inp.value.length;
    
    if (curLen < old){
      old--;
      return;
      }
      
    if (curLen == 4)
      inp.value = inp.value + "(";
    if (curLen == 7)
    	inp.value = inp.value + ")-";
      
     if (curLen == 12)
    	inp.value = inp.value + "-"; 
      
     if (curLen == 15)
    	inp.value = inp.value + "-";  
      
     if (curLen > 18)
    	inp.value = inp.value.substring(0, inp.value.length - 1);
      
     old++;
});

inp.addEventListener('keypress', e => {
  // Отменяем ввод не цифр
  if(!/\d/.test(e.key))
    e.preventDefault();
});