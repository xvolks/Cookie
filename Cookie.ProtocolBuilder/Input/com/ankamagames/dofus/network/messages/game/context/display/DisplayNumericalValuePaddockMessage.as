package com.ankamagames.dofus.network.messages.game.context.display
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DisplayNumericalValuePaddockMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6563;
       
      
      private var _isInitialized:Boolean = false;
      
      public var rideId:int = 0;
      
      public var value:int = 0;
      
      public var type:uint = 0;
      
      public function DisplayNumericalValuePaddockMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6563;
      }
      
      public function initDisplayNumericalValuePaddockMessage(param1:int = 0, param2:int = 0, param3:uint = 0) : DisplayNumericalValuePaddockMessage
      {
         this.rideId = param1;
         this.value = param2;
         this.type = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.rideId = 0;
         this.value = 0;
         this.type = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_DisplayNumericalValuePaddockMessage(param1);
      }
      
      public function serializeAs_DisplayNumericalValuePaddockMessage(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.rideId);
         param1.writeInt(this.value);
         param1.writeByte(this.type);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DisplayNumericalValuePaddockMessage(param1);
      }
      
      public function deserializeAs_DisplayNumericalValuePaddockMessage(param1:ICustomDataInput) : void
      {
         this._rideIdFunc(param1);
         this._valueFunc(param1);
         this._typeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DisplayNumericalValuePaddockMessage(param1);
      }
      
      public function deserializeAsyncAs_DisplayNumericalValuePaddockMessage(param1:FuncTree) : void
      {
         param1.addChild(this._rideIdFunc);
         param1.addChild(this._valueFunc);
         param1.addChild(this._typeFunc);
      }
      
      private function _rideIdFunc(param1:ICustomDataInput) : void
      {
         this.rideId = param1.readInt();
      }
      
      private function _valueFunc(param1:ICustomDataInput) : void
      {
         this.value = param1.readInt();
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
         if(this.type < 0)
         {
            throw new Error("Forbidden value (" + this.type + ") on element of DisplayNumericalValuePaddockMessage.type.");
         }
      }
   }
}
