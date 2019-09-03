function charRemover(myString){
	var mySecondString = "";
	var myArray = myString.split("");
	var separatorsSet = new Set([' ', "	", ",", ".", "?", "!", ";" ,":"]);
	var charSet = new Set();
	for (var i = 0; i < myArray.length; i++) {
		if (separatorsSet.has(myArray[i])) {
			charSet.clear();
			continue;
		}
		else if(charSet.has(myArray[i])){
			mySecondString = myString.split(myArray[i]).join("");
			myString = mySecondString;
		}
		else charSet.add(myArray[i])
	}
	return mySecondString;
}

console.log(charRemover("У попа была собака"));