import React, { Component } from "react";
import { Layout, Breadcrumb } from "antd";
import FormDiv from '../Home/Form';
const { Content } = Layout;




class ContentDiv extends Component {
  render() {
    return (
      <Content style={{ padding: "0 50px" }}>
        <Breadcrumb style={{ margin: "16px 0" }}>
          <Breadcrumb.Item>Home</Breadcrumb.Item>
          <Breadcrumb.Item>List</Breadcrumb.Item>
          <Breadcrumb.Item>App</Breadcrumb.Item>
        </Breadcrumb>
        
        <div className="site-layout-content"><FormDiv></FormDiv></div>





      </Content>
    );
  }
}
export default ContentDiv;
