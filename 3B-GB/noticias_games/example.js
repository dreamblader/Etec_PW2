let x = 5;
let y = 0;

let vetor = [1 , 5 , 7 , 9];

let obj = {cor:"vermelho", quantidade:5, tamanho:1.5};




do
{
    console.log(x);
    x++;
} while(x<=10); //ENQUANTO

for (let i = 0; i < vetor.length; i++) 
{
    console.log(vetor[i]);
}

for(let coisa in obj)
{
    console.log(coisa);
}


switch(x)
{
    case 1: // if(x==1)
        //alguma coisa
        break;
    case 2: // if(x==2)
        //outra coisa
        break;
    case 3:
        //outra coisa
        break;
    default:
        //coisa padrão
        break;
}

if(x==1)
{

}
else if(x==2)
{

}
else if(x==3)
{

}
else{
    
}

let z = x>5 ? 3 : 2;

if(x>5)
{
    let z =3;
}
else
{
    let z= 2;
}



let resultado = x + y;


/*
DoWhile, 
While, 
For, LAÇOS DE REPETIÇÃO
For In,
For To, 
quando usar Switch e quando usar IF, 
IF Ternário, 
Vetores (Arrays), 
Dicionarios (Dictionary, Map)
*/