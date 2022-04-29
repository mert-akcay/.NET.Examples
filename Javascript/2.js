console.log("2" == 2);

var btn = document.querySelector("#btnB");
var field = document.querySelector(".container");
/* btn.addEventListener("click", () => {
  var httpReq = new XMLHttpRequest();

  httpReq.open("GET", "https://dog.ceo/api/breeds/image/random", true);
  httpReq.send();
  httpReq.onload = (e) => {
    var img = document.createElement("img");
    img.src = JSON.parse(httpReq.responseText).message;
    field.innerHTML = "";
    field.appendChild(img);
  };
}); */
loadImg()

function loadImg() {
  var httpReq = new XMLHttpRequest();

  httpReq.open(
    "GET",
    "https://api.openweathermap.org/data/2.5/onecall?lat=41.042&lon=29.004&&exclude=current,minutely,hourly,alerts&units=metric&appid=cd9627f52cd66d3c8523176411238956",
    true
  );
  httpReq.send();




  httpReq.onload = (e) => {
    var data = JSON.parse(httpReq.responseText);
    data.daily.forEach((e,i) => {
        if(i===0)return
        var element = document.createElement("div");
        element.classList.add("element")

        var h3 = document.createElement("h3")
        h3.textContent = e.weather[0].main;

        var h2 = document.createElement("h2")
        console.log(e.dt)
        var date = new Date(e.dt * 1000)
        console.log(date)
        h2.textContent = date.getDate()


        var img = document.createElement("img")
        img.src = `http://openweathermap.org/img/wn/${e.weather[0].icon}@2x.png`

        element.appendChild(h2)
        element.appendChild(h3)
        element.appendChild(img)
        field.appendChild(element)
    });
  };
}

function firstRepeat(arr) {
  var resArr = [];

  for (let i = 0; i < arr.length - 1; i++) {
    if (arr[i] === arr[i + 1] && !resArr.includes(arr[i])) {
      resArr.push(arr[i]);
      i++;
    }
  }
  return resArr;
}
