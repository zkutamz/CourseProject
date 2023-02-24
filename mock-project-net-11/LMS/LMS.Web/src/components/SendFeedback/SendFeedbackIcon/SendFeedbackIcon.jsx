import React from 'react';

SendFeedbackIcon.propTypes = {

};

function SendFeedbackIcon (props) {

    return (
        <>
            <a href="feedback.html" className="menu--link" title="Send Feedback">
                <i className="uil uil-comment-alt-exclamation menu--icon" />
                <span className="menu--label">Send Feedback</span>
            </a>
        </>
    );
}
export default SendFeedbackIcon;