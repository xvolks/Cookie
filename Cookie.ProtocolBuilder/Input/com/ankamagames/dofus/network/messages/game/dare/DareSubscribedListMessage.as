package com.ankamagames.dofus.network.messages.game.dare
{
   import com.ankamagames.dofus.network.types.game.dare.DareInformations;
   import com.ankamagames.dofus.network.types.game.dare.DareVersatileInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class DareSubscribedListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6658;
       
      
      private var _isInitialized:Boolean = false;
      
      public var daresFixedInfos:Vector.<DareInformations>;
      
      public var daresVersatilesInfos:Vector.<DareVersatileInformations>;
      
      private var _daresFixedInfostree:FuncTree;
      
      private var _daresVersatilesInfostree:FuncTree;
      
      public function DareSubscribedListMessage()
      {
         this.daresFixedInfos = new Vector.<DareInformations>();
         this.daresVersatilesInfos = new Vector.<DareVersatileInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6658;
      }
      
      public function initDareSubscribedListMessage(param1:Vector.<DareInformations> = null, param2:Vector.<DareVersatileInformations> = null) : DareSubscribedListMessage
      {
         this.daresFixedInfos = param1;
         this.daresVersatilesInfos = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.daresFixedInfos = new Vector.<DareInformations>();
         this.daresVersatilesInfos = new Vector.<DareVersatileInformations>();
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
         this.serializeAs_DareSubscribedListMessage(param1);
      }
      
      public function serializeAs_DareSubscribedListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.daresFixedInfos.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.daresFixedInfos.length)
         {
            (this.daresFixedInfos[_loc2_] as DareInformations).serializeAs_DareInformations(param1);
            _loc2_++;
         }
         param1.writeShort(this.daresVersatilesInfos.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.daresVersatilesInfos.length)
         {
            (this.daresVersatilesInfos[_loc3_] as DareVersatileInformations).serializeAs_DareVersatileInformations(param1);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_DareSubscribedListMessage(param1);
      }
      
      public function deserializeAs_DareSubscribedListMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:DareInformations = null;
         var _loc7_:DareVersatileInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = new DareInformations();
            _loc6_.deserialize(param1);
            this.daresFixedInfos.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = new DareVersatileInformations();
            _loc7_.deserialize(param1);
            this.daresVersatilesInfos.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_DareSubscribedListMessage(param1);
      }
      
      public function deserializeAsyncAs_DareSubscribedListMessage(param1:FuncTree) : void
      {
         this._daresFixedInfostree = param1.addChild(this._daresFixedInfostreeFunc);
         this._daresVersatilesInfostree = param1.addChild(this._daresVersatilesInfostreeFunc);
      }
      
      private function _daresFixedInfostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._daresFixedInfostree.addChild(this._daresFixedInfosFunc);
            _loc3_++;
         }
      }
      
      private function _daresFixedInfosFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DareInformations = new DareInformations();
         _loc2_.deserialize(param1);
         this.daresFixedInfos.push(_loc2_);
      }
      
      private function _daresVersatilesInfostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._daresVersatilesInfostree.addChild(this._daresVersatilesInfosFunc);
            _loc3_++;
         }
      }
      
      private function _daresVersatilesInfosFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:DareVersatileInformations = new DareVersatileInformations();
         _loc2_.deserialize(param1);
         this.daresVersatilesInfos.push(_loc2_);
      }
   }
}
