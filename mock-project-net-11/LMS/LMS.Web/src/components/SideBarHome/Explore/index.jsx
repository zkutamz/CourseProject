import React from 'react';
import PropTypes from 'prop-types';

Explore.propTypes = {

};

function Explore (props) {
    function exploreClicked(e) {
        console.log('exploreClicked');
    }

    return (
        <>
            <a onClick={exploreClicked} className="menu--link" title="Explore">
                <i className="uil uil-search menu--icon" />
                <span className="menu--label">Explore</span>
            </a>
        </>
    );
}

export default Explore;