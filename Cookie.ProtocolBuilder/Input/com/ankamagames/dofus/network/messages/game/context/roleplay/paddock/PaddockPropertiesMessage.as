package com.ankamagames.dofus.network.messages.game.context.roleplay.paddock
{
   import com.ankamagames.dofus.network.types.game.paddock.PaddockInstancesInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PaddockPropertiesMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5824;
       
      
      private var _isInitialized:Boolean = false;
      
      public var properties:PaddockInstancesInformations;
      
      private var _propertiestree:FuncTree;
      
      public function PaddockPropertiesMessage()
      {
         this.properties = new PaddockInstancesInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5824;
      }
      
      public function initPaddockPropertiesMessage(param1:PaddockInstancesInformations = null) : PaddockPropertiesMessage
      {
         this.properties = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.properties = new PaddockInstancesInformations();
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
         this.serializeAs_PaddockPropertiesMessage(param1);
      }
      
      public function serializeAs_PaddockPropertiesMessage(param1:ICustomDataOutput) : void
      {
         this.properties.serializeAs_PaddockInstancesInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PaddockPropertiesMessage(param1);
      }
      
      public function deserializeAs_PaddockPropertiesMessage(param1:ICustomDataInput) : void
      {
         this.properties = new PaddockInstancesInformations();
         this.properties.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PaddockPropertiesMessage(param1);
      }
      
      public function deserializeAsyncAs_PaddockPropertiesMessage(param1:FuncTree) : void
      {
         this._propertiestree = param1.addChild(this._propertiestreeFunc);
      }
      
      private function _propertiestreeFunc(param1:ICustomDataInput) : void
      {
         this.properties = new PaddockInstancesInformations();
         this.properties.deserializeAsync(this._propertiestree);
      }
   }
}
