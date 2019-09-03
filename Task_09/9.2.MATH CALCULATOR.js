function calculator(mathString){
    var numbArray = mathString.split(/\+|\-|\*|\//);
    var count = 1;
    var summ = +numbArray[0];
    for(var i = 0; i < mathString.length; i++){
        
        switch(mathString[i]) {
            case "+" :
                summ += +numbArray[count];
                count++;
                break;
            case "-" :
                summ -= +numbArray[count];
                count++;
                break;
            case "*" :
                summ *= +numbArray[count];
                count++;
                break;
            case "/" :
                summ /= +numbArray[count];
                count++;
                break;
        }
    }
    return summ.toFixed(2);
}

console.log(calculator("3.5 +4*10-5.3 /5"));