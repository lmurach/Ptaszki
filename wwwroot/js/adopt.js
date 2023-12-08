onStart();

function onStart() {
    const AdoptEles = document.querySelectorAll('.adopt-button');
    AdoptEles.forEach(function(btn) {
        btn.addEventListener('click', function(e) {
            postAdopt(e);
        })
    });
}

async function postAdopt(e) {
    let adoptObj = {};
    adoptObj.buttonId = e.target.id.replace('adopt-button-', '');
    if (adoptObj.buttonId != 999) {
        // let data = new FormData(form);
        // let feedback  = Object.fromEntries(data.entries());

        let json = JSON.stringify(adoptObj);
        
        try {
            let resp = await fetch('/api/adopt', {
                method: 'post',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: json
            });
            if (!resp.ok) {
                throw(`An error occurred while posting feedback: ${await resp.text()}`);
            }
        }
        catch (ex) {
            // addError(ex);
        }
        await getAdopt();
    }
    onStart();
}

async function getAdopt() {
    try {
        let resp = await fetch('/api/adopt');
        if (!resp.ok) {
            throw(`An error occurred retrieving feedback: ${await resp.text()}`);
        }

        let user = await resp.json();
        console.log(user);

        var adoptEntries = document.querySelectorAll('.adopt-entry');
        var ssEntries = document.querySelectorAll('.side-shop-entry');

        for (var i = 0; i < 7; i++) {
            var html = `
            <img class="side-shop-img"
                src="/images/bird_avatars/${user.sideShopBirds[i].bird.id}.jpg">
            `;
            if (user.sideShopBirds[i].bird.id != 999) {
                html += `<img class="ss-star ss-star-1" src="/images/site/star.png">`
            }
            if (user.sideShopBirds[i].star == 2) {
                html += `<img class="ss-star ss-star-2" src="/images/site/star.png">`
            }
            ssEntries[i].innerHTML = html;
        }

        for (var i = 0; i < 3; i++) {
            if (user.rolledSSBs[i].bird.id == 999) {
                adoptEntries[i].className = `adopt-entry empty-bird`
                adoptEntries[i].innerHTML = ``;
            }
            else {
                adoptEntries[i].className = `adopt-entry rarity-${user.rolledSSBs[i].bird.rarity}`
                adoptEntries[i].innerHTML = `
                <img class="adopt-img" src="/images/bird_avatars/${user.rolledSSBs[i].bird.id}.jpg">
                <div class="adopt-name">
                    <h2>${user.rolledSSBs[i].bird.name}</h2>
                </div>
                <div class="adopt-stats">
                    <ul>
                        <li>
                            <img class="stat-img" src="/images/site/strength.png">
                            Strength: ${user.rolledSSBs[i].bird.strength}
                        </li>
                        <li>
                            <img class="stat-img" src="/images/site/perception.png">
                            Perception: ${user.rolledSSBs[i].bird.perception}
                        </li>
                        <li>
                            <img class="stat-img" src="/images/site/hunting.png">
                            Hunting: ${user.rolledSSBs[i].bird.hunting}
                        </li>
                    </ul>
                </div>
                <div class="adopt-description">
                    ${user.rolledSSBs[i].bird.description}
                </div>
                <button class="adopt-button" id="adopt-button-${i}">Adopt</button>
                `
            }
        }
    }
    catch (ex) {
        console.log(ex);
    }
}