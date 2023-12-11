OnStart();
var pickedFlag = false;

function OnStart() {
    const SubmitBtn = document.querySelector('.job-submit-button');
    console.log(SubmitBtn);
    SubmitBtn.addEventListener('click', function() {
        postDailyJob();
    });
    const ViewBirdEles = document.querySelectorAll('.view-bird-entry');
    ViewBirdEles.forEach(function(btn) {
        btn.addEventListener('click', function(e) {
            postPickBird(e);
        })
    });
    const JobBirdsEle = document.querySelectorAll('.job-bird-img');
    JobBirdsEle.forEach(function (btn) {
        btn.addEventListener('click', function(e) {
            postRemoveBird(e);
        })
    });
}

async function postPickBird(e) {
    if (pickedFlag){
        return;
    }
    pickedFlag = true;
    console.log(e.currentTarget);
    let viewBirdObj = {};
    viewBirdObj.birdId = e.currentTarget.id.replace('view-bird-', '');
    console.log(viewBirdObj.birdId);
    let json = JSON.stringify(viewBirdObj);
    
    try {
        let resp = await fetch('/api/pickbird', {
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
    await getPickBird();
    OnStart();
    pickedFlag = false;
}

async function getPickBird() {
    try {
        let resp = await fetch('/api/pickbird');
        if (!resp.ok) {
            throw(`An error occurred retrieving feedback: ${await resp.text()}`);
        }

        let user = await resp.json();
        fillJobBox(user);
        fillOwnedBirdsBox(user);
        
    }
    catch (ex) {
        console.log(ex);
    }
}

function fillJobBox(user) {
    let divEle = document.querySelector(".view-birds-grid");
        divEle.innerHTML = ``
        for (let birdConn of user.ownedBirds) {
            var ownedFlag = false;
            for (let uBird of user.jobBirds) {
                if (uBird.bird.id == birdConn.bird.id) {
                    ownedFlag = true;
                }
            }
            if (!ownedFlag) {
                divEle.innerHTML += ` 
                    <div class="view-bird-entry rarity-${birdConn.bird.rarity}" 
                        id="view-bird-${birdConn.bird.id}">
                        <div class="vb-img-container">
                            <img class="vb-img" src="/images/bird_avatars/${birdConn.bird.id}.jpg">
                        </div>
                        <div class="vb-entry-name">${birdConn.bird.name}</div>
                        <div class="vb-entry-stats-container">
                            <div class="vb-entry-stat">
                                <img class="stat-img" src="/images/site/strength.png">
                                ${birdConn.bird.strength}
                            </div>
                            <div class="vb-entry-stat">
                                <img class="stat-img" src="/images/site/perception.png">
                                ${birdConn.bird.perception}
                            </div>
                            <div class="vb-entry-stat">
                                <img class="stat-img" src="/images/site/hunting.png">
                                ${birdConn.bird.hunting}
                            </div>
                        </div>
                    </div>
                `
            }
        }
}

function fillOwnedBirdsBox(user) {
    var birdBarEle = document.querySelector(".job-birds-bar");
    birdBarEle.innerHTML = "";
    for (let i = 0; i < 5; i++) {
        const jobsBirdEntry = document.createElement("div");
        jobsBirdEntry.className = "job-birds-entry";
        jobsBirdEntry.id = `jobs-bird-${i}`
        jobsBirdEntry.innerHTML += `                
            <img class="job-bird-img" 
            src="/images/bird_avatars/${user.jobBirds[i].bird.id}.jpg"
            id="bird-img-${user.jobBirds[i].bird.id}">
        `
        birdBarEle.appendChild(jobsBirdEntry);

        if (user.jobBirds[i].bird.id != 999) {
            const birdBarNode = document.createElement("div");
            birdBarNode.className = "job-dropdowns";
            birdBarNode.innerHTML = `
                <label for="job-titles">Choose job:</label> 
                <select name="job-titles" id="job-titles"> 
                    <option value="seed-collector">Seed collector</option> 
                    <option value="hunter">Hunter</option> 
                    <option value="rock-breaker">Rock Breaker</option> 
                    <option value="gatherer">Gatherer</option> 
                    <option value="feather-fetcher">Feather Fetcher</option>
                    <option value="bug-finder">Bug Finder</option> 
                </select>
            `
            jobsBirdEntry.appendChild(birdBarNode);
        }
    }
}

async function postRemoveBird(e) {
    let removeBirdObj = {};
    var birdDiv = e.currentTarget.parentNode;
    var birdImg = e.currentTarget;
    removeBirdObj.birdId = birdImg.id.replace('bird-img-', '');
    if (removeBirdObj.birdId != "999") {
        removeBirdObj.birdPosition = birdDiv.id.replace('jobs-bird-', '');
        let json = JSON.stringify(removeBirdObj);
        
        try {
            let resp = await fetch('/api/removebird', {
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
        await getRemoveBird();
    }
    OnStart();
}

async function getRemoveBird() {
    try {
        let resp = await fetch('/api/removebird');
        if (!resp.ok) {
            throw(`An error occurred retrieving feedback: ${await resp.text()}`);
        }

        let user = await resp.json();
        fillJobBox(user);
        fillOwnedBirdsBox(user);
    }
    catch (ex) {
        console.log(ex);
    }
}

async function postDailyJob() {
    var dropdown = document.querySelectorAll(".job-titles");
    console.log(dropdown[0].value);
    var dropdownObj = {}
    for (let i = 0; i < dropdown.length; i++) {
        dropdownObj[`Bird${i}`] = dropdown[i].value;
    }
    console.log(dropdownObj);
    let json = JSON.stringify(dropdownObj);
    console.log(json);
    try {
        let resp = await fetch('/api/dailyjob', {
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
    await getDailyJob();
    OnStart();
}

async function getDailyJob() {
    try {
        let resp = await fetch('/api/dailyjob');
        if (!resp.ok) {
            throw(`An error occurred retrieving feedback: ${await resp.text()}`);
        }

        let yields = await resp.json();
        yieldEle = document.querySelector('.yield-fill-box');
        yieldEle.innerHTML = "";
            for (let yield of yields){
                yE = document.createAttribute("div");
                yE.innerHTML = `
                    The <span class="rarity-${yield.bird.rarity}">${yield.bird.name}</span> 
                    found ${yield.amount} ${yield.basicItemName}.
                `
                yieldEle.appendChild(yE);
            }
    }
    catch (ex) {
        console.log(ex);
    }
}