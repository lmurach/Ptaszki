// console.log("js running");
// const AdoptEles = document.querySelectorAll('.adopt-button');
// AdoptEles.forEach(function(btn) {
//     console.log(btn);
//     btn.addEventListener('click', function(e) {
//         postAdopt(e);
//     })
// });

// async function postAdopt(e) {
//     let adoptObj = {};
//     adoptObj.buttonId = e.target.id.replace('adopt-button-', '');
//     console.log(adoptObj.buttonId);

//     // let data = new FormData(form);
//     // let feedback  = Object.fromEntries(data.entries());

//     let json = JSON.stringify(adoptObj);
//     console.log(json);
    
//     try {
//         let resp = await fetch('/api/adopt', {
//             method: 'post',
//             headers: {
//                 'Accept': 'application/json',
//                 'Content-Type': 'application/json'
//             },
//             body: json
//         });
//         if (!resp.ok) {
//             throw(`An error occurred while posting feedback: ${await resp.text()}`);
//         }
//         var img = e.target.parentNode.children[0];
        
//         var sideShopImgs = document.querySelectorAll('.side-shop-img');

//         for (var i = 0; i < sideShopImgs.length; i++) {
//             if (sideShopImgs[i].src.includes("999.jpg")) {
//                 sideShopImgs[i].src = img.src;
//                 break;
//             }
//         }
//         img.src = "/images/bird_avatars/999.jpg"
//     }
//     catch (ex) {
//         // addError(ex);
//     }
// }