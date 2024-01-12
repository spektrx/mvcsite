let bh = document.getElementById("bot_hand")
let ph = document.getElementById("player_hand")
let pscr = document.getElementById("pl_score")
let coin = 100
let fcoin = document.getElementById("coins")
let game

let bet_str = document.getElementById("bet_str");
let u_bet = document.getElementById("u_bet")
let bet = 0
let bet_btn = document.getElementById("play_bet_btn")

let hare_btn = document.getElementById("hare")
let vzat_btn = document.getElementById("vzat")
let gstatus = document.getElementById("game_status")
hare_btn.hidden = true
vzat_btn.hidden = true

bet_str.setAttribute("max",coin)

fcoin.innerHTML = coin

u_bet.innerHTML = 0

function sleep(milliseconds) {
  const date = Date.now();
  let currentDate = null;
  do {
    currentDate = Date.now();
  } while (currentDate - date < milliseconds);
}

function play_bet(){
  bet_str.setAttribute("max",coin)
  bet = bet_str.value
  if(bet <= coin && bet>=1){
  hare_btn.hidden = false
  vzat_btn.hidden = false
  gstatus.innerHTML= "Идёт игра"

  bet_btn.hidden = true
  
  coin -= bet
  fcoin.innerHTML = coin
  u_bet.innerHTML = bet

  deck = shuffle(deck_create())
  game = start(deck)
  console.log(game.player_hand, game.bot_hand, game.deck)
  printDeck()
  fscore(game.player_hand)
}

}


function bot_take_card(){
  vzat_btn.hidden = true
  hare_btn.hidden = true
  bh.innerHTML = game.bot_hand.join(" ")
  
  bot_score=fscore(game.bot_hand)
  player_score=fscore(game.player_hand)
  console.log(bot_score)
  
  
    
    var i = 1;                  //  set your counter to 1

function myLoop() {         //  create a loop function
  setTimeout(function() {   //  call a 3s setTimeout when the loop is called
    console.log("dsd1")
    
    card = game.deck.pop()
    game.bot_hand.push(card)
    bot_score=fscore(game.bot_hand)
   
    bh.innerHTML = game.bot_hand.join(" ");   //  your code here
    i++;                    //  increment the counter
    if (bot_score < player_score) {           //  if the counter < 10, call the loop function
      myLoop();             //  ..  again which will trigger another 
    }
    else{
      
        
      

      if(bot_score>21){
        gstatus.innerHTML=  "перебор у дилера"
        win()
      }
      else if(bot_score > player_score){
        gstatus.innerHTML= "дилер побеждает"
        gameover()
    
      }
      else if(bot_score < player_score){
        gstatus.innerHTML= "Вы выиграли"
        win()
    }
      else{
        gstatus.innerHTML="Ничья" 
          tie()
    
      }
     

    }                       //  ..  setTimeout()
  }, 1000)


  
}

myLoop();   


    
    
    

  

  

}



function deck_create(){
    console.log("hello world")
    let rang =["2","3","4","5","6","7","8","9","10","J","Q","K","A"]
    let mast = ["♣","♠","♥","♦"]
    let deck = []
    for (index in mast){
        let i = mast[index]
        for(index2 in rang){
            let k = rang[index2]
            deck.push(i+k)
           
        }
    }
    return deck
}


function shuffle(array) {
    let currentIndex = array.length,  randomIndex;
    
    while (currentIndex != 0) {
      
      randomIndex = Math.floor(Math.random() * currentIndex);
      currentIndex--;
      
      [array[currentIndex], array[randomIndex]] = [
        array[randomIndex], array[currentIndex]];
    }
    return array;
  }

function start(deck){
  let player_hand = []
  let bot_hand = []
  let card
  for(i=0; i<2; i++){
    
    
    card = deck.pop()
    player_hand.push(card)
   

  
    
  }
  card = deck.pop()
  bot_hand.push(card)
  
  

  let game = {"player_hand": player_hand, "bot_hand": bot_hand, "deck":deck}
  return game
}

function printDeck(){
  bh.innerHTML = game.bot_hand[0]
  ph.innerHTML = game.player_hand.join(" ")
}
function isNumeric(str) {
  if (typeof str != "string") return false // we only process strings!  
  return !isNaN(str) && // use type coercion to parse the _entirety_ of the string (`parseFloat` alone does not do this)...
         !isNaN(parseFloat(str)) // ...and ensure strings of whitespace fail
}





function fscore(deck){
  console.log("schitayu po novoy")
  let count = 0
  
  console.log(deck)
  let score = 0
  score=0
  for(i in deck){
    
    let card = deck[i]
    card = card.substring(1)
    
    if(isNumeric(card)){
      score += parseInt(card)
      console.log(score, parseInt(card))
    }
    else if (card === "A"){
      score += 11
      console.log(score, "11")
    }
    else{
      score += 10
      console.log(score, "10")
    }

  
  if(score > 21){
    count = 0
    
    for(i in deck){
      
      if(deck[i].indexOf("A")>=0){
        
        count++
        
      }

    }

  
  
  }
  }

  for(let i=0; i<count; i++){
    console.log("for")
    if(score>21){
      score -= 10
      console.log("-10")
    }
  }
  
  console.log("score: ", score)
  return score
  //pscr.innerHTML = score
}




function take_card_button(){
  game.player_hand = take_card(game.player_hand)
  fscore(game.player_hand)
}




function player_take_card(){
  console.log("plsl")
  card = game.deck.pop()
  game.player_hand.push(card)
  ph.innerHTML = game.player_hand.join(" ")
  console.log(game.player_hand)
  score = fscore(game.player_hand)
  if(score>=22){
    
    gameover()
    gstatus.innerHTML= "У вас перебор"
    
  }

}

function gameover(){
  u_bet.innerHTML = 0

  hare_btn.hidden = true
  vzat_btn.hidden = true

  bet_btn.hidden = false

  fcoin.innerHTML = coin
}

function win(){
  u_bet.innerHTML = 0

  hare_btn.hidden = true
  vzat_btn.hidden = true

  bet_btn.hidden = false

  coin += parseInt(bet)*2

  fcoin.innerHTML = coin

}

function tie(){
  u_bet.innerHTML = 0

  hare_btn.hidden = true
  vzat_btn.hidden = true

  bet_btn.hidden = false

  coin += parseInt(bet)

  fcoin.innerHTML = coin

}




