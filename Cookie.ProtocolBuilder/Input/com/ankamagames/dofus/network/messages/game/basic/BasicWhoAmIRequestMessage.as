package com.ankamagames.dofus.network.messages.game.basic
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class BasicWhoAmIRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5664;
       
      
      private var _isInitialized:Boolean = false;
      
      public var verbose:Boolean = false;
      
      public function BasicWhoAmIRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5664;
      }
      
      public function initBasicWhoAmIRequestMessage(param1:Boolean = false) : BasicWhoAmIRequestMessage
      {
         this.verbose = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.verbose = false;
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
         this.serializeAs_BasicWhoAmIRequestMessage(param1);
      }
      
      public function serializeAs_BasicWhoAmIRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.verbose);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_BasicWhoAmIRequestMessage(param1);
      }
      
      public function deserializeAs_BasicWhoAmIRequestMessage(param1:ICustomDataInput) : void
      {
         this._verboseFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_BasicWhoAmIRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_BasicWhoAmIRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._verboseFunc);
      }
      
      private function _verboseFunc(param1:ICustomDataInput) : void
      {
         this.verbose = param1.readBoolean();
      }
   }
}
