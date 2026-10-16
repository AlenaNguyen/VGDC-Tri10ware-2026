using System;

public class Dialogue
{
    // Question will always be in index 0
    // Correct answer will always be in index 1
    public static string[][] dogQuestionBank = new string[][]
    {
        // EASY
        new string[] {"\"By the way, thanks for taking me out to PawRice Center for our two hour anniversary!\"",
        "No problem babe. If this date goes well, let's get MARRIED!",
        "Yeah whatever.",
        "Dude, chill out.",
        "I don't really like dogs..."},

        new string[] {"\"Here's hoping you don't spend all your time on your phone instead of your girlfriend!\"",
        "Baby, I would never betray you like that!",
        "I love my phone...",
        "Controlling much? Geez.",
        "But what about all the online hotties I'm definitely not flirting with?"},

        new string[] {"\"Don't you dare ignore me. I hate distracted little things.\"",
        "I'll throw you a tennis ball any time you want!",
        "You're not going to force me to touch grass, right?",
        "I don't like needy girls...",
        "Cool ENOUGH?"},

        new string[] {"\"I'm so hungry so I could eat a...\"",
        "...balanced meal!",
        "... kibble?",
        "I'm not hungry. I'm never hungry. I don't eat.",
        "Are you referencing something?"},

        new string[] {"\"You better get ready for some questions! Can't be dating loser idiots who aren't quick on their feet.\"",
        "I'm ready babe. Give me ALL of your challenges.",
        "What, this is a test?!",
        "I actually identify as a chud...",
        "GRRRRRRRR BARBARKBARKBARKBARKKKK"},

        // MEDIUM
        new string[] {"\"I prefer order. Any number that isn't even irritates me, got it?\"",
        "12",
        "13",
        "10.5",
        "1"},

        new string[] {"\"Which is the outlier?\"",
        "Light",
        "Sharp",
        "Wit",
        "Bright"},

        new string[] {"\"Never use words than end in -er around me, ok?\"",
        "I'm no instigator!",
        "You won't catch me being a whiner!",
        "Look at this debbie downer!",
        "Lover, as you command!"},

        new string[] {"\"Which is the outlier?\"",
        "Halt",
        "Move",
        "Reach",
        "Stretch"},

        new string[] {"\"A pet name is only cute if it isn't food related.\"",
        "Got it, cuddlebug!",
        "Sure, honeypie!",
        "Whatever you say, muffin!",
        "Okey dokey artichokey!"},

        // HARD
        new string[] {"\"How many fries do you want?\"",
        "80% of 10!",
        "3",
        "Four and a half!",
        "7"},

        new string[] {"\"How many corners are there in a triangle?\"",
        "More than 2, less than 4",
        "More than five",
        "More than 2, less than 1",
        "3"},

        new string[] {"\"What's the correct spelling for:\"",
        "perserverance?",
        "perversance?",
        "perceveranse?",
        "pervercanse?"},

        new string[] {"\"What's the best thing here?\"",
        "Half of twenty!",
        "Any even integer",
        "The number 3!",
        "Any even number"},

        new string[] {"\"Tell me something sweet.\"",
        "You're the best 2nd girlfriend in the world!",
        "You're the apple of my eye!",
        "You're even prettier by the minute!",
        "You're the best 1st girlfriend in the world!"},

        // EXTRA HARD

        new string[] {"\"What's the best thing to eat here?\"",
        "H-O-T-D-O-G",
        "B-U-R-G-E-R",
        "F-R-I-E-S",
        "P-I-Z-Z-A"},
        
        new string[] {"\"How do you really feel about this relationship?\"",
        "Love, we're such a good pair!",
        "Darling, I love you x3!",
        "Cupcake, you keep things in such good order!",
        "Angel, I'll love you forever!"},

        new string[] {"\"Quickly. What's 5+2-3?\"",
        "The number between 6 and 8!",
        "The number between 4 and 6!",
        "The number 7!",
        "The number 8!"},

        new string[] {"\"Wow, we've been dating a while.\"",
        "It's been the best two hours of my life!",
        "You might be my one true soulmate!",
        "We're going to be together forever!",
        "Sugarmuffin, I adore you!"},

        new string[] {"\"Which doesn't fit?\"",
        "Skim",
        "Bar",
        "Line",
        "Plot"}
    };

    public static string[][] catQuestionBank = new string[][]
    {
        // EASY 

        new string[] {"DMing now, are we :33 ?next thing you know is marriage~",
        "yessssss ^w^ i hope you dont mindddd",
        "y are u typing like that.",
        "u sent me a friend request two hours ago chill",
        "*ignores*"},

        new string[] {"i'm kinda shy hdskdjsfddjsfk-",
        "i'll get u to come out of ur shell >:D",
        "dude it's not 2021 anymore stop texting like that",
        "ur keyboard smash needs work :/",
        "kys"},

        new string[] {"everyone always ends up ghosting or cheating on me TwT",
        "i'm not like the others. i don't cheat",
        "do u think u might be the problem",
        "it's because you text like a thirteen year old",
        "yea i prolly will too"},

        new string[] {"what do u think of soft catboys....... <3",
        "they're the cutest !!!! :333",
        "i like 'em EVIL",
        "they're pathetic and not in a cute way",
        "grown ass man btw"},

        new string[] {"you don't mind if i ask you some questions, right?? hhhghh i just have to make sure you're the right person to protect me",
        "i'm ur loyal alpha. ask me anything u want",
        "ummm...",
        "not another catboy with anxious analyser avoidant abysmal attachment style...",
        "i'm actually just a little kitten as well uwu"},

        // MEDIUM

        new string[] {"cats have 4 paws :3 i really like multiples of 4, and hate all other numbers!",
        "8",
        "9",
        "7",
        "6"},

        new string[] {"one of these doesn't fit...",
        "frog",
        "fish",
        "beg",
        "ask"},

        new string[] {"an owo means YES, and an -w- means NO, ok???",
        "owo",
        "-w-",
        "huh?",
        "i'm not using that furry lingo LOL"},

        new string[] {"i HATE words than end in -en, ok?? if u use them ur DNI !!",
        "okey dokey owo",
        "ok queen",
        "what about ramen??",
        "but what about 67...."},

        new string[] {"i <3 pet names :3 the sweeter the better!!!",
        "what about sugarmuffin?",
        "ok honeybear :3",
        "heehee what about lovebug??",
        "ok studmuffin :pp"},

        // HARD

        new string[] {"what time should our next date be? :3",
        "12:00 AM",
        "5:00 PM",
        "9:00 AM",
        "10:00 PM"},

        new string[] {"how many kisses do i get?? ^w^",
        "204 !!!",
        "175 :p",
        "333 :)",
        "15! :D"},

        new string[] {"do u love me furever?",
        "yessss owo",
        "yessss -w-",
        "nooooo owo",
        "not at all -w-"},

        new string[] {"gimme the best response! 4*3 = ??",
        "twelve",
        "owo",
        "a dozen",
        "-w-"},

        new string[] {"yes yes no yes",
        "owo owo -w- owo",
        "-w- owo -wo uwu",
        "-w- -w- owo -w-",
        "uwu owo -w- owo"},

        // EXTRA HARD

        new string[] {"yes no yes yeno nyes",
        "owo -w- owo ow- -wo",
        "-w- owo owo owo -w-",
        "-w- owo owo owo -w-",
        "owo -w- -wo owo ow-"},

        new string[] {"2+5+4-1 = ??",
        "10",
        "9",
        "11",
        "3"},

        new string[] {"how do u spell ...",
        "worcestershire?",
        "worcesterchire?",
        "worcestrshire?",
        "worcesterrshire?"},

        new string[] {"*sigh* ive felt kinda ignored by u...",
        "sweetiepie, ur my love 4rever",
        "preciousmuffin, i care about u 2 much",
        "honeybun, ur the 1 for me",
        "snookums, i like the number 7"},

        new string[] {"one of these doesnt fit!!!",
        "beckon",
        "judge",
        "assess",
        "count"}
                
    };
}