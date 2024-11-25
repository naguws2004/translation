// Using single quotes
const greeting = 'Hola, mundo.';

// Using double quotes
const name = "Alice";

// Using template literals for string interpolation
const message = `Hello, ${name}!`;

// Multi-line strings using template literals
const poem = `Las rosas son rojas, las violetas azules, JavaScript es increíble, ¡y tú también!`;

// Escaping characters within strings
const quote = "She said, \"JavaScript is fun!\"";

console.log(greeting); // Outputs: Hola, mundo.
console.log(message); // Outputs: Hello, Alice!
console.log(poem);
console.log(quote); // Outputs: Me dijo: "¡JavaScript es divertido!".

// program to replace all occurrence of a string

const string = 'Mr red has a red house and a red car';

const result = string.split('red').join('blue');

console.log(result);

// program to replace all occurrence of a string

const string = 'Mr Red has a red house and a red car';

// regex expression
const regex = /red/gi;

// replace the characters
const newText = string.replace(regex, 'blue');

// display the result
console.log(newText);