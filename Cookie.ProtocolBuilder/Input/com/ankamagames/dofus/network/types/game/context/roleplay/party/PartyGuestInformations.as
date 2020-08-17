package com.ankamagames.dofus.network.types.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.character.status.PlayerStatus;
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.companion.PartyCompanionBaseInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PartyGuestInformations implements INetworkType
   {
      
      public static const protocolId:uint = 374;
       
      
      public var guestId:Number = 0;
      
      public var hostId:Number = 0;
      
      public var name:String = "";
      
      public var guestLook:EntityLook;
      
      public var breed:int = 0;
      
      public var sex:Boolean = false;
      
      public var status:PlayerStatus;
      
      public var companions:Vector.<PartyCompanionBaseInformations>;
      
      private var _guestLooktree:FuncTree;
      
      private var _statustree:FuncTree;
      
      private var _companionstree:FuncTree;
      
      public function PartyGuestInformations()
      {
         this.guestLook = new EntityLook();
         this.status = new PlayerStatus();
         this.companions = new Vector.<PartyCompanionBaseInformations>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 374;
      }
      
      public function initPartyGuestInformations(param1:Number = 0, param2:Number = 0, param3:String = "", param4:EntityLook = null, param5:int = 0, param6:Boolean = false, param7:PlayerStatus = null, param8:Vector.<PartyCompanionBaseInformations> = null) : PartyGuestInformations
      {
         this.guestId = param1;
         this.hostId = param2;
         this.name = param3;
         this.guestLook = param4;
         this.breed = param5;
         this.sex = param6;
         this.status = param7;
         this.companions = param8;
         return this;
      }
      
      public function reset() : void
      {
         this.guestId = 0;
         this.hostId = 0;
         this.name = "";
         this.guestLook = new EntityLook();
         this.sex = false;
         this.status = new PlayerStatus();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyGuestInformations(param1);
      }
      
      public function serializeAs_PartyGuestInformations(param1:ICustomDataOutput) : void
      {
         if(this.guestId < 0 || this.guestId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.guestId + ") on element guestId.");
         }
         param1.writeVarLong(this.guestId);
         if(this.hostId < 0 || this.hostId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.hostId + ") on element hostId.");
         }
         param1.writeVarLong(this.hostId);
         param1.writeUTF(this.name);
         this.guestLook.serializeAs_EntityLook(param1);
         param1.writeByte(this.breed);
         param1.writeBoolean(this.sex);
         param1.writeShort(this.status.getTypeId());
         this.status.serialize(param1);
         param1.writeShort(this.companions.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.companions.length)
         {
            (this.companions[_loc2_] as PartyCompanionBaseInformations).serializeAs_PartyCompanionBaseInformations(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyGuestInformations(param1);
      }
      
      public function deserializeAs_PartyGuestInformations(param1:ICustomDataInput) : void
      {
         var _loc5_:PartyCompanionBaseInformations = null;
         this._guestIdFunc(param1);
         this._hostIdFunc(param1);
         this._nameFunc(param1);
         this.guestLook = new EntityLook();
         this.guestLook.deserialize(param1);
         this._breedFunc(param1);
         this._sexFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserialize(param1);
         var _loc3_:uint = param1.readUnsignedShort();
         var _loc4_:uint = 0;
         while(_loc4_ < _loc3_)
         {
            _loc5_ = new PartyCompanionBaseInformations();
            _loc5_.deserialize(param1);
            this.companions.push(_loc5_);
            _loc4_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyGuestInformations(param1);
      }
      
      public function deserializeAsyncAs_PartyGuestInformations(param1:FuncTree) : void
      {
         param1.addChild(this._guestIdFunc);
         param1.addChild(this._hostIdFunc);
         param1.addChild(this._nameFunc);
         this._guestLooktree = param1.addChild(this._guestLooktreeFunc);
         param1.addChild(this._breedFunc);
         param1.addChild(this._sexFunc);
         this._statustree = param1.addChild(this._statustreeFunc);
         this._companionstree = param1.addChild(this._companionstreeFunc);
      }
      
      private function _guestIdFunc(param1:ICustomDataInput) : void
      {
         this.guestId = param1.readVarUhLong();
         if(this.guestId < 0 || this.guestId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.guestId + ") on element of PartyGuestInformations.guestId.");
         }
      }
      
      private function _hostIdFunc(param1:ICustomDataInput) : void
      {
         this.hostId = param1.readVarUhLong();
         if(this.hostId < 0 || this.hostId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.hostId + ") on element of PartyGuestInformations.hostId.");
         }
      }
      
      private function _nameFunc(param1:ICustomDataInput) : void
      {
         this.name = param1.readUTF();
      }
      
      private function _guestLooktreeFunc(param1:ICustomDataInput) : void
      {
         this.guestLook = new EntityLook();
         this.guestLook.deserializeAsync(this._guestLooktree);
      }
      
      private function _breedFunc(param1:ICustomDataInput) : void
      {
         this.breed = param1.readByte();
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
      }
      
      private function _statustreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.status = ProtocolTypeManager.getInstance(PlayerStatus,_loc2_);
         this.status.deserializeAsync(this._statustree);
      }
      
      private function _companionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._companionstree.addChild(this._companionsFunc);
            _loc3_++;
         }
      }
      
      private function _companionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PartyCompanionBaseInformations = new PartyCompanionBaseInformations();
         _loc2_.deserialize(param1);
         this.companions.push(_loc2_);
      }
   }
}
