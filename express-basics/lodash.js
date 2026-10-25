const _ = require("lodash");

const arr = [1,2,3,4,5];
const numbers  = _.concat(arr, [[6,7,8,9,10]]);
console.log(...numbers);

const numbers2 = _.flatten(numbers);
console.log(...numbers2);