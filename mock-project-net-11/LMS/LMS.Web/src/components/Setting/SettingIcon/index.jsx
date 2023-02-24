import React from 'react';

SettingIcon.propTypes = {

};

function SettingIcon (props) {

    return (
        <>
            <a href="setting.html" className="menu--link" title="Setting">
                <i className="uil uil-cog menu--icon" />
                <span className="menu--label">Setting</span>
            </a>
        </>
    );
}
export default SettingIcon;