var str = '3.5 + 4*10-5.3/5=';

alert(mathCalculator(str));

function mathCalculator(expr) {
    var result;
    var temp;

    expr = expr.replace(/\s+/g, '');

    var mathSigns = expr.match(/[\+\-\*\/=]+/g);
    var numbers = expr.match(/[\d]*[.]?[\d]+/g);

    result = parseFloat(numbers[0]);
    numbers.splice(0, 1);

    for (var i = 0; i < mathSigns.length - 1; i++) {
        var j = parseFloat(numbers[0]);
        numbers.splice(0, 1);

        result = myEval(result, j, mathSigns[i]);


    }
    return result.toFixed(2);
}

function myEval(val1, val2, sign) {
    switch (sign) {
        case '+':
            return parseFloat(val1 + val2);

        case '-':
            return parseFloat(val1 - val2);

        case '*':
            return parseFloat(val1 * val2);

        case '/':
            return parseFloat(val1 / val2);
    }
}