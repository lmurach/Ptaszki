onStart();

function onStart() {
    const ViewBirdEles = document.querySelectorAll('.view-bird-entry');
    ViewBirdEles.forEach(function(btn) {
        btn.addEventListener('click', function(e) {
            postViewBird(e);
        })
    });
}

async function postViewBird(e) {
    console.log(e.currentTarget);
    let viewBirdObj = {};
    viewBirdObj.birdId = e.currentTarget.id.replace('view-bird-', '');
    let json = JSON.stringify(viewBirdObj);
    console.log(json);
    
    try {
        let resp = await fetch('/api/viewbird', {
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
    // await getViewBird();
    onStart();
}