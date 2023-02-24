import React from 'react';
import PropTypes from 'prop-types';

LiveStream.propTypes = {

};

function LiveStream (props) {

    function liveStreamClicked(e) {
        console.log('liveStreamClicked');
    }

    return (
        <>
            <a onClick={liveStreamClicked} className="menu--link" title="Live Streams">
                <i className="uil uil-kayak menu--icon" />
                <span className="menu--label">Live Streams</span>
            </a>
        </>
    );
}

export default LiveStream;