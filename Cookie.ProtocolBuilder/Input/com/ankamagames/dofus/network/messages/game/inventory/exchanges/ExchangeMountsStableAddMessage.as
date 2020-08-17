package com.ankamagames.dofus.network.messages.game.inventory.exchanges
{
   import com.ankamagames.dofus.network.types.game.mount.MountClientData;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ExchangeMountsStableAddMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6555;
       
      
      private var _isInitialized:Boolean = false;
      
      public var mountDescription:Vector.<MountClientData>;
      
      private var _mountDescriptiontree:FuncTree;
      
      public function ExchangeMountsStableAddMessage()
      {
         this.mountDescription = new Vector.<MountClientData>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6555;
      }
      
      public function initExchangeMountsStableAddMessage(param1:Vector.<MountClientData> = null) : ExchangeMountsStableAddMessage
      {
         this.mountDescription = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.mountDescription = new Vector.<MountClientData>();
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
         this.serializeAs_ExchangeMountsStableAddMessage(param1);
      }
      
      public function serializeAs_ExchangeMountsStableAddMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.mountDescription.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.mountDescription.length)
         {
            (this.mountDescription[_loc2_] as MountClientData).serializeAs_MountClientData(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ExchangeMountsStableAddMessage(param1);
      }
      
      public function deserializeAs_ExchangeMountsStableAddMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:MountClientData = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new MountClientData();
            _loc4_.deserialize(param1);
            this.mountDescription.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ExchangeMountsStableAddMessage(param1);
      }
      
      public function deserializeAsyncAs_ExchangeMountsStableAddMessage(param1:FuncTree) : void
      {
         this._mountDescriptiontree = param1.addChild(this._mountDescriptiontreeFunc);
      }
      
      private function _mountDescriptiontreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._mountDescriptiontree.addChild(this._mountDescriptionFunc);
            _loc3_++;
         }
      }
      
      private function _mountDescriptionFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:MountClientData = new MountClientData();
         _loc2_.deserialize(param1);
         this.mountDescription.push(_loc2_);
      }
   }
}
