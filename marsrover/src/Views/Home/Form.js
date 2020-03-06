import React, { Component } from "react";
import { Form, Input, Button, InputNumber } from "antd";
import axios from "axios";

class FormDiv extends Component {
  constructor(props) {
    super(props);
    this.state = {
      someVal: "Osman Yalçınkaya",
      DimensionX: "",
      DimensionY: "",
      StartPoint: "",
      Command: ""
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleClick = this.handleClick.bind(this);
    this.inputNumberChange = this.inputNumberChange.bind(this);
    this.inputNumberChange2 = this.inputNumberChange2.bind(this);
  }

  handleClick() {
    const sendData = {
      Commands: this.state.Command,
      StartCoordinateX: this.state.StartPoint.substring(0, 1),
      StartCoordinateY: this.state.StartPoint.substring(1, 2),
      StartDirection: this.state.StartPoint.substring(2, 3),
      DimensionX: this.state.DimensionX,
      DimensionY: this.state.DimensionY
    };

    axios
      .post(`http://testapi.dustu.net/api/command`, {
        headers: { "Access-Control-Allow-Origin": "*" },
        sendData
      })
      .then(res => {
        console.log(res);
        console.log(res.data);
      });
    console.log(this.state);
  }

  handleChange(event) {
    const target = event.target;
    const value = target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  }

  inputNumberChange(data) {
    this.setState({
      DimensionX: data
    });
  }
  inputNumberChange2(data) {
    this.setState({
      DimensionY: data
    });
  }

  render() {
    const layout = {
      labelCol: { span: 3 },
      wrapperCol: { span: 8 }
    };
    const tailLayout = {
      wrapperCol: { offset: 3, span: 8 }
    };

    return (
      <Form {...layout} name="basic" initialValues={{ remember: true }}>
        <Form.Item
          label="DimensionX"
          name="DimensionX"
          rules={[
            { required: true, message: "Plato için X ekseni boyutu giriniz!" }
          ]}
        >
          <InputNumber
            min={1}
            max={100}
            defaultValue={1}
            name="DimensionX"
            onChange={this.inputNumberChange}
          />
        </Form.Item>

        <Form.Item
          label="DimensionY"
          name="DimensionY"
          rules={[
            { required: true, message: "Plato için Y ekseni boyutu giriniz!" }
          ]}
        >
          <InputNumber
            min={1}
            max={100}
            defaultValue={1}
            onChange={this.inputNumberChange2}
            name="DimensionY"
          />
        </Form.Item>

        <Form.Item
          label="Başlangıç Noktası"
          name="StartPoint"
          rules={[
            {
              required: true,
              message: "Başlangıç noktası koordinatlarını giriniz!"
            }
          ]}
        >
          <Input name="StartPoint" onChange={this.handleChange} />
        </Form.Item>

        <Form.Item
          label="Komut"
          name="Command"
          rules={[
            { required: true, message: "Aracın izleyeceği komutları giriniz!" }
          ]}
        >
          <Input name="Command" onChange={this.handleChange} />
        </Form.Item>

        <Form.Item label="Sonuç" name="5">
          <div>{this.state.someVal}</div>
        </Form.Item>
        <Form.Item {...tailLayout}>
          <Button type="primary" onClick={this.handleClick}>
            Gönder
          </Button>
        </Form.Item>
      </Form>
    );
  }
}

export default FormDiv;
