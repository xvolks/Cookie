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
   public class BasicWhoIsRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 181;
       
      
      private var _isInitialized:Boolean = false;
      
      public var verbose:Boolean = false;
      
      public var search:String = "";
      
      public function BasicWhoIsRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 181;
      }
      
      public function initBasicWhoIsRequestMessage(param1:Boolean = false, param2:String = "") : BasicWhoIsRequestMessage
      {
         this.verbose = param1;
         this.search = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.verbose = false;
         this.search = "";
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
         this.serializeAs_BasicWhoIsRequestMessage(param1);
      }
      
      public function serializeAs_BasicWhoIsRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeBoolean(this.verbose);
         param1.writeUTF(this.search);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_BasicWhoIsRequestMessage(param1);
      }
      
      public function deserializeAs_BasicWhoIsRequestMessage(param1:ICustomDataInput) : void
      {
         this._verboseFunc(param1);
         this._searchFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_BasicWhoIsRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_BasicWhoIsRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._verboseFunc);
         param1.addChild(this._searchFunc);
      }
      
      private function _verboseFunc(param1:ICustomDataInput) : void
      {
         this.verbose = param1.readBoolean();
      }
      
      private function _searchFunc(param1:ICustomDataInput) : void
      {
         this.search = param1.readUTF();
      }
   }
}
