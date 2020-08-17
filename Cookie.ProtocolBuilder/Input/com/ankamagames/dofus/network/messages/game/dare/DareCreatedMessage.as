package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.dofus.network.types.game.dare.DareInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareCreatedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6668;
       
      
      private var _isInitialized:Boolean = false;
      
      public var dareInfos:DareInformations;
      
      public var needNotifications:Boolean = false;
      
      private var _dareInfostree:FuncTree;
      
      public function DareCreatedMessage()
      {
         this.dareInfos = new DareInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6668;
      }
      
      public function initDareCreatedMessage(param1:DareInformations = null, param2:Boolean = false) : DareCreatedMessage
      {
         this.dareInfos = param1;
         this.needNotifications = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.dareInfos = new DareInformations();
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
         this.serializeAs_DareCreatedMessage(param1);
      }
      
      public function serializeAs_DareCreatedMessage(param1:ICustomDataOutput) : void
      {
         this.dareInfos.serializeAs_DareInformations(param1);
         param1.writeBoolean(this.needNotifications);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareCreatedMessage(param1);
      }
      
      public function deserializeAs_DareCreatedMessage(param1:ICustomDataInput) : void
      {
         this.dareInfos = new DareInformations();
         this.dareInfos.deserialize(param1);
         this._needNotificationsFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareCreatedMessage(param1);
      }
      
      public function deserializeAsyncAs_DareCreatedMessage(param1:FuncTree) : void
      {
         this._dareInfostree = param1.addChild(this._dareInfostreeFunc);
         param1.addChild(this._needNotificationsFunc);
      }
      
      private function _dareInfostreeFunc(param1:ICustomDataInput) : void
      {
         this.dareInfos = new DareInformations();
         this.dareInfos.deserializeAsync(this._dareInfostree);
      }
      
      private function _needNotificationsFunc(param1:ICustomDataInput) : void
      {
         this.needNotifications = param1.readBoolean();
      }
   }
}
