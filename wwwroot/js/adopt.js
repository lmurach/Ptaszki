const bird_ele = document.getElementById('reroll-button');

// #region API call to POST New Feedback

form.addEventListener('submit', async function (event) {

    let feedback = {};
    feedback.rating = form.elements.rating.value;
    feedback.email = form.elements.email.value;
    feedback.text = form.elements.text.value;

    // let data = new FormData(form);
    // let feedback  = Object.fromEntries(data.entries());

    let json = JSON.stringify(feedback);
    console.log(json);
    
    try {
        let resp = await fetch('/api/feedback', {
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
        addError(ex);
    }

    await getFeedback();
    form.reset();

});
