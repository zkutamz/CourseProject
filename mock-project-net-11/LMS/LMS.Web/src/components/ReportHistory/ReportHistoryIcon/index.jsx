import React from 'react';

ReportHistoryIcon.propTypes = {

};

function ReportHistoryIcon (props) {

    return (
        <>
            <a href="report_history.html" className="menu--link" title="Report History">
                <i className="uil uil-windsock menu--icon" />
                <span className="menu--label">Report History</span>
            </a>
        </>
    );
}
export default ReportHistoryIcon;