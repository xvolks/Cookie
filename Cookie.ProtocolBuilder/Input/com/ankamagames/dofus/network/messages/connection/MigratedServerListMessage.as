package com.ankamagames.dofus.network.messages.connection
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MigratedServerListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6731;
       
      
      private var _isInitialized:Boolean = false;
      
      public var migratedServerIds:Vector.<uint>;
      
      private var _migratedServerIdstree:FuncTree;
      
      public function MigratedServerListMessage()
      {
         this.migratedServerIds = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6731;
      }
      
      public function initMigratedServerListMessage(param1:Vector.<uint> = null) : MigratedServerListMessage
      {
         this.migratedServerIds = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.migratedServerIds = new Vector.<uint>();
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
         this.serializeAs_MigratedServerListMessage(param1);
      }
      
      public function serializeAs_MigratedServerListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.migratedServerIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.migratedServerIds.length)
         {
            if(this.migratedServerIds[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.migratedServerIds[_loc2_] + ") on element 1 (starting at 1) of migratedServerIds.");
            }
            param1.writeVarShort(this.migratedServerIds[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MigratedServerListMessage(param1);
      }
      
      public function deserializeAs_MigratedServerListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhShort();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of migratedServerIds.");
            }
            this.migratedServerIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MigratedServerListMessage(param1);
      }
      
      public function deserializeAsyncAs_MigratedServerListMessage(param1:FuncTree) : void
      {
         this._migratedServerIdstree = param1.addChild(this._migratedServerIdstreeFunc);
      }
      
      private function _migratedServerIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._migratedServerIdstree.addChild(this._migratedServerIdsFunc);
            _loc3_++;
         }
      }
      
      private function _migratedServerIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of migratedServerIds.");
         }
         this.migratedServerIds.push(_loc2_);
      }
   }
}
