import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import AuthContext from '../../store/auth-context';
import MessageIcon from '../Message/MessageIcon';
import NotificationIcon from '../Notification/NotificationIcon';
import ShoppingCartIcon from '../ShoppingCart/ShoppingCartIcon';
import UserIcon from '../User/UserIcon';

function HeaderRight() {
  const authContext = useContext(AuthContext);
  return (
    <div className="header_right">
      <ul>
        {
          authContext.role == 'Instructor' &&
          <li>
            <Link to="instructor/create-new-course" className="upload_btn" title="Create New Course">
              Create New Course
            </Link>
          </li>
        }
        {/* ShoppingCartIcon component */}
        <ShoppingCartIcon />
        {/* MessageIcon component */}
        <MessageIcon />
        {/* NotificationIcon component */}
        <NotificationIcon />
        {/* UserIcon component */}
        <UserIcon />
      </ul>
    </div>
  );
}

export default HeaderRight;
