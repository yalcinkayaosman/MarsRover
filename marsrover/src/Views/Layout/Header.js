import React, { Component } from "react";
import { Layout, Menu } from "antd";
const { Header } = Layout;

class HeaderDiv extends Component {
  render() {
    return (
      <Header>
        <div className="logo" />
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={["21"]}
          style={{ lineHeight: "64px" }}
        >
          <Menu.Item key="1">Menü 1</Menu.Item>
          <Menu.Item key="2">Menü 2</Menu.Item>
          <Menu.Item key="3">Menü 3</Menu.Item>
        </Menu>
      </Header>
    );
  }
}

export default HeaderDiv;
