console.log(charRemover('У попа была собака '));

function charRemover(str) {
    var duplicates = findDuplicates(str);
    var result = charReplace(str, duplicates);

    function findDuplicates(str) {
        var separators = [' ', '.', ','];
        var buf = '';
        var repeatSymbols = [];

        nextIteration:
        for (var i = 0; i < str.length; i++) {
            for (var j = 0; j < separators.length; j++) {
                if (str[i] == separators[j]) {
                    repeatSymbols.push(unique(buf));
                    buf = '';
                    continue nextIteration;
                }
            }
            buf += str[i];
        }
        return repeatSymbols.join('').split('');
    }

    function unique(arr) {
        var result = [];
        var duplicates = [];

        nextInput:
        for (var i = 0; i < arr.length; i++) {
            var str = arr[i];
            for (var j = 0; j < result.length; j++) {
                if (result[j] == str) {
                    duplicates.push(str);
                    continue nextInput;
                }
            }
            result.push(str);
        }

        duplicates = duplicates.filter(function(elem, index, self) {
            return index == self.indexOf(elem);
        })
        return duplicates;
    }
    
    function charReplace(inputStr, chars) {
        for (var i = 0;i < chars.length; i++) {
        	var regex = new RegExp(chars[i] ,'gim');
          alert(regex);
          inputStr = inputStr.replace(regex, '');
      }
      return inputStr;
  }
  return result;
}