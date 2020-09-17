let fileNames = [
    "kitten1.jpg",
    "kitten2.jpg",
    "kitten3.jpg",
    "kitten4.jpg",
];

let browserImages = document.querySelectorAll("img");


for (var i = 0; i < browserImages.length; i++) {
    let mixPictures = Math.floor(Math.random() * fileNames.length);
    let file = "kittens/" + fileNames[mixPictures];
    let url = chrome.extension.getURL(file);
    browserImages[i].src = url;
}

console.log("It's my first chrome extension, OMG!");