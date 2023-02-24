import React from 'react';
import SideBarHome from '../SideBarHome';
import SideBarInstructorDashboard from '../SideBarInstructorDashboard';
import SideBarStudentDashboard from '../SideBarStudentDashboard';
import SideBarInstructor from '../SideBarInstructor/SideBarInstructor';

class SideBar extends React.Component {
  constructor(props) {
    super(props);
    this.state = { token: localStorage.getItem("token") }
  }

  componentDidMount() {
    this.setState({
      token: localStorage.getItem("token")
    });
  }

  render() {
    if (this.props.page == 'InstructorDashboard') {
      return <SideBarInstructor minify={this.props.minify} />
    }
    if (this.props.page == 'StudentDashboard') {
      // return StudentDashboard sidebar
      return <SideBarStudentDashboard />
    }
    return <SideBarHome minify={this.props.minify} />
  }

}

export default SideBar;
